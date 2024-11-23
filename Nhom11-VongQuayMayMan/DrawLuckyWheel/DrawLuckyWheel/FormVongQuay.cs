using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.IO;

namespace DrawLuckyWheel
{
    public partial class FormVongQuay : Form
    {
        bool wheelIsMoved;
        float wheelTimes;
        Timer wheelTimer;
        LuckyCirlce koloFortuny;
        List<string> inputStrings; // Store the input text instead of numbers
        List<Label> wheelLabels; // Store the labels for the wheel
        int spinCount = 0;
        List<string> spinHistory = new List<string>(); // Store each result in this list
        private bool isSpinCompleted = false;

        public FormVongQuay()
        {
            InitializeComponent();
            wheelTimer = new Timer();
            wheelTimer.Interval = 30; // Speed of rotation
            wheelTimer.Tick += wheelTimer_Tick;
            inputStrings = new List<string>();
            wheelLabels = new List<Label>(); // Initialize the list for labels
            this.textBoxNumber.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxNumber_KeyDown);

        }

        public class LuckyCirlce
        {
            public Bitmap obrazek;
            public Bitmap tempObrazek;
            public float kat;
            public string[] wartosciStanu; // Use string array instead of int array
            public int stan;

            public LuckyCirlce(string[] texts)
            {
                tempObrazek = new Bitmap(Properties.Resources.lucky_wheel);
                obrazek = new Bitmap(Properties.Resources.lucky_wheel);
                wartosciStanu = texts;
                kat = 0.0f;
            }
        }

        public static Bitmap RotateImage(Image image, float angle)
        {
            return RotateImage(image, new PointF((float)image.Width / 2 - 2, (float)image.Height / 2 - 7), angle);
        }

        public static Bitmap RotateImage(Image image, PointF offset, float angle)
        {
            if (image == null)
                throw new ArgumentNullException("image");

            Bitmap rotatedBmp = new Bitmap(image.Width, image.Height);
            rotatedBmp.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            Graphics g = Graphics.FromImage(rotatedBmp);
            g.TranslateTransform(offset.X, offset.Y);
            g.RotateTransform(angle);
            g.TranslateTransform(-offset.X, -offset.Y);
            g.DrawImage(image, new PointF(0, 0));

            return rotatedBmp;
        }

        private void RotateImage(PictureBox pb, Image img, float angle)
        {
            if (img == null || pb.Image == null)
                return;

            Image oldImage = pb.Image;
            pb.Image = RotateImage(img, angle);
            if (oldImage != null)
            {
                oldImage.Dispose();
            }
        }

        private void wheelTimer_Tick(object sender, EventArgs e)
        {
            if (wheelIsMoved && wheelTimes > 0)
            {
                koloFortuny.kat += wheelTimes / 10;
                koloFortuny.kat = koloFortuny.kat % 360;
                RotateImage(pictureBox, koloFortuny.obrazek, koloFortuny.kat);
                UpdateLabelPositions(koloFortuny.kat, inputStrings.Count);
                wheelTimes--;
            }

            if (inputStrings.Count > 0)
            {
                koloFortuny.stan = ((int)Math.Round((360 - koloFortuny.kat) / (360 / inputStrings.Count)) + inputStrings.Count) % inputStrings.Count;

                if (koloFortuny.stan == 0)
                {
                    koloFortuny.stan = 0;
                }
                if (wheelTimes == 0 && !isSpinCompleted)
                {
                    string result = inputStrings[koloFortuny.stan];
                    spinHistory.Add(result); // Add result to history

                    // Display spin history (e.g., in a ListBox or Label)
                    listBoxHistory.Items.Add($"Spin {spinCount}: {result}");
                    // Show pop-up with result and firework effect
                 
                    isSpinCompleted = true; // Set flag to prevent repeated addition
                    Firework fireworkForm = new Firework(result);
                    fireworkForm.ShowDialog(); // Show the form modally
                }

                label1.Text = inputStrings[koloFortuny.stan]; // Display text instead of number
            }
            else
            {
                label1.Text = ""; // Clear label if no inputs
            }
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            if (inputStrings.Count == 0)
            {
                MessageBox.Show("Please enter some text to spin.");
                return;
            }

            koloFortuny = new LuckyCirlce(inputStrings.ToArray());
            wheelIsMoved = true;
            Random rand = new Random();
            wheelTimes = rand.Next(150, 200);
            wheelTimer.Start();
            spinCount++;
            labelSpinCount.Text = $"Spin Count: {spinCount}";
            isSpinCompleted = false;

        }
        private void textBoxNumber_KeyDown(object sender, KeyEventArgs e)
        {
            // Check if the Enter key was pressed
            if (e.KeyCode == Keys.Enter)
            {
                // Add the text from the TextBox to the list
                if (!string.IsNullOrWhiteSpace(textBoxNumber.Text)) // Ensure it's not empty
                {
                    inputStrings.Add(textBoxNumber.Text); // Add the input text to the list
                    textBoxNumber.Clear(); // Clear the TextBox after adding

                    // Create or update labels based on the current input
                    CreateLabels();
                    UpdateLabelPositions(0, inputStrings.Count); // Update initial positions
                }
                else
                {
                    MessageBox.Show("Please enter valid text.");
                }
            }
            // Optionally, you can handle other key events (e.g., Escape for clearing)
            else if (e.KeyCode == Keys.Escape)
            {
                textBoxNumber.Clear(); // Clear the TextBox if Escape is pressed
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBoxNumber.Text)) // Check if input is not empty
            {
                inputStrings.Add(textBoxNumber.Text); // Add the input string
                textBoxNumber.Clear(); // Clear input box after adding
                CreateLabels(); // Create labels based on current input
                UpdateLabelPositions(0, inputStrings.Count); // Update initial positions
            }
            else
            {
                MessageBox.Show("Please enter valid text.");
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            inputStrings.Clear(); // Clear input strings
            textBoxNumber.Clear(); // Clear input box
            foreach (var label in wheelLabels)
            {
                this.Controls.Remove(label);
                label.Dispose(); // Dispose old labels
            }
            wheelLabels.Clear(); // Clear labels list
            koloFortuny.kat = 0.0f; // Reset angle
            koloFortuny.obrazek = new Bitmap(Properties.Resources.lucky_wheel); // Reset image
            pictureBox.Image = koloFortuny.obrazek; // Update PictureBox
            label1.Text = "No Text"; // Indicate no text available
            spinCount = 0;
            spinHistory.Clear();
            listBoxHistory.Items.Clear(); // Clear history display
            labelSpinCount.Text = "Spin Count: 0";
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBoxNumber.Text)) // Check if input is valid
            {
                int index = inputStrings.IndexOf(textBoxNumber.Text); // Find the text to edit

                if (index != -1)
                {
                    string newValueInput = Microsoft.VisualBasic.Interaction.InputBox("Enter the new value for " + textBoxNumber.Text, "Edit Text", textBoxNumber.Text);

                    if (!string.IsNullOrWhiteSpace(newValueInput))
                    {
                        inputStrings[index] = newValueInput; // Update string
                        wheelLabels[index].Text = newValueInput; // Update label text directly
                        textBoxNumber.Clear(); // Clear input box after editing
                    }
                    else
                    {
                        MessageBox.Show("Please enter a valid new value.");
                    }
                }
                else
                {
                    MessageBox.Show("Text not found in the list.");
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid text to edit.");
            }
        }
        private bool IsNumber(string input)
        {
            return int.TryParse(input, out _); // Return true if it's a valid number, false otherwise
        }
        // Create and position the labels dynamically based on inputStrings
        private void CreateLabels()
        {
            // Determine if the latest input is a number
            bool isNumber = IsNumber(inputStrings.Last());

            // Create a new label based on the input type (number or text)
            Label label = new Label
            {
                Text = inputStrings.Last(),
                TextAlign = ContentAlignment.MiddleCenter,
                BackColor = Color.Transparent,
                ForeColor = Color.Black,
                Font = isNumber ? new Font("Arial", 13, FontStyle.Bold) : new Font("Arial", 12, FontStyle.Bold)
            };

            // Set specific properties based on input type
            if (isNumber)
            {
                label.Size = new Size(50, 25);
            }
            else
            {
                label.AutoSize = true;
            }

            // Add the label to the form and to the list
            wheelLabels.Add(label);
            this.Controls.Add(label);

            // Update label positions if necessary
            UpdateLabelPositions(0, inputStrings.Count);
        }


        // Update label positions to rotate with the wheel
        private void UpdateLabelPositions(double currentAngle, int numSegments)
        {
            double anglePerSegment = 360f / numSegments;
            double radius = pictureBox.Width / 2 - 250;
            PointF center = new PointF(pictureBox.Width / 2 - 120, pictureBox.Height / 2 - 50);

            for (int i = 0; i < numSegments; i++)
            {
                double angle = currentAngle + (i * 36) - 90;
                double x = center.X + radius * (double)Math.Cos(angle * Math.PI / 180);
                double y = center.Y + radius * (double)Math.Sin(angle * Math.PI / 180);

                wheelLabels[i].Location = new Point((int)x, (int)y);
                wheelLabels[i].Visible = true;
                wheelLabels[i].BringToFront();
            }
        }
        private void btnSaveTemplate_Click(object sender, EventArgs e)
        {
            if (inputStrings.Count == 0)
            {
                MessageBox.Show("Please enter some text to save as a template.");
                return;
            }

            // Prompt user for a custom file name
            string fileName = Microsoft.VisualBasic.Interaction.InputBox("Enter a name for the template file:", "Save Wheel Template", "wheel_template");

            if (string.IsNullOrWhiteSpace(fileName))
            {
                MessageBox.Show("Please enter a valid file name.");
                return;
            }

            // Let user choose the folder to save the template
            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                folderDialog.Description = "Select a folder to save the template file";
                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    // Combine the selected folder path with the file name
                    string fullPath = Path.Combine(folderDialog.SelectedPath, fileName + ".txt");

                    try
                    {
                        File.WriteAllLines(fullPath, inputStrings);
                        MessageBox.Show("Template saved successfully at: " + fullPath);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred while saving the template: " + ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("No folder selected. Template was not saved.");
                }
            }
        }
        private void btnLoadTemplate_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*",
                Title = "Open Wheel Template"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Load the text from the file into inputStrings
                    inputStrings = File.ReadAllLines(openFileDialog.FileName).ToList();

                    // Clear existing items using btnRemove_Click
                    foreach (var label in wheelLabels)
                    {
                        this.Controls.Remove(label);
                        label.Dispose(); // Dispose old labels
                    }
                    wheelLabels.Clear(); // Clear labels list
                    koloFortuny.kat = 0.0f; // Reset angle
                    koloFortuny.obrazek = new Bitmap(Properties.Resources.lucky_wheel); // Reset image
                    pictureBox.Image = koloFortuny.obrazek; // Update PictureBox
                    spinCount = 0;
                    spinHistory.Clear();
                    listBoxHistory.Items.Clear(); // Clear history display
                    labelSpinCount.Text = "Spin Count: 0";

                    // Create labels based on the loaded inputStrings
                    if (inputStrings.Count > 0)
                    {
                        // Iterate through each item in inputStrings and create labels
                        foreach (var input in inputStrings)
                        {
                            Label label = new Label
                            {
                                Text = input,
                                TextAlign = ContentAlignment.MiddleCenter,
                                BackColor = Color.Transparent,
                                ForeColor = Color.Black,
                                Font = IsNumber(input) ? new Font("Arial", 13, FontStyle.Bold) : new Font("Arial", 12, FontStyle.Bold)
                            };

                            // Set specific properties based on input type
                            if (IsNumber(input))
                            {
                                label.Size = new Size(50, 25);
                            }
                            else
                            {
                                label.AutoSize = true;
                            }

                            // Add the label to the form and to the list
                            wheelLabels.Add(label);
                            this.Controls.Add(label);
                        }

                        // Update label positions after creating all labels
                        UpdateLabelPositions(0, inputStrings.Count);
                        
                    }
                    else
                    {
                        MessageBox.Show("The template file is empty.");
                    }

                    MessageBox.Show("Template loaded successfully.");
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while loading the template: " + ex.Message);
                }
            }
        }


        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FormVongQuay_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Tạo một instance của FormMenu
            FormMeNu formMenu = new FormMeNu();

            // Hiển thị FormMenu
            formMenu.Show();

            //this.Dispose();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
