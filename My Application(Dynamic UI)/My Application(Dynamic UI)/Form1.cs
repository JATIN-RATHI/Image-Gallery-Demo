using System;
using System.Drawing;
using System.Windows.Forms;

namespace My_Application_Dynamic_UI_
{
    public partial class Form1 : System.Windows.Forms.Form
    {
        //creating instance of controls we are using in form
        private Label name = new Label();
        private TextBox enterName = new TextBox();
        private Label roll = new Label();
        private TextBox enterRoll = new TextBox();
        private Label course = new Label();
        private TextBox enterCourse = new TextBox();
        private Label gender = new Label();
        private RadioButton male = new RadioButton();
        private RadioButton female = new RadioButton();
        private RadioButton others = new RadioButton();
        private Label job = new Label();
        private CheckBox chkJob = new CheckBox();
        private Button submit = new Button();
        private Button clear = new Button();
        public Form1()
        {
            InitializeComponent();
        }
       
        //setting properties 
        private void Form1_Load(object sender, EventArgs e)
        {
            //form 
            StartPosition = FormStartPosition.CenterScreen;
            Text = "My App (Dynamic UI) Demo";
            Size = new Size(280, 300);

            //name label
            name.Text = "Name : ";
            name.Location = new Point(10, 25); //(x, y)
            name.Size = new Size(45, 20);      //(ht, wt)
            //adding name Label in form
            Controls.Add(name);

            //name textbox 
            enterName.Location = new Point(60, 25);

            //adding name textbox in form
            Controls.Add(enterName);

            //roll Label
            roll.Text = "Roll No. :";
            roll.Size = new Size(55, 20);
            roll.Location = new Point(10, 50);
            //adding roll Label
            Controls.Add(roll);

            //roll textbox
            enterRoll.Location = new Point(70, 50);
            //adding roll textbox
            Controls.Add(enterRoll);

            //course Label
            course.Text = "Course : ";
            course.Size = new Size(55, 20);
            course.Location = new Point(10, 75);
            //adding label course
            Controls.Add(course);

            //course textbox
            enterCourse.Location = new Point(70, 75);
            //ADDING course textbox
            Controls.Add(enterCourse);

            //gender label
            gender.AutoSize = true;
            gender.Location = new Point(10, 100);
            gender.Text = "Gender :";
            //adding gender label
            Controls.Add(gender);

            //male radiobutton
            male.AutoSize = true;
            male.Text = "Male";
            male.Location = new Point(80, 100);
            //adding male radiobutton
            Controls.Add(male);

            //Female radiobutton
            female.AutoSize = true;
            female.Text = "Female";
            female.Location = new Point(80, 120);
            //adding female radiobutton
            Controls.Add(female);

            //Others radiobutton
            others.AutoSize = true;
            others.Text = "Others";
            others.Location = new Point(80, 140);
            //adding others radiobutton
            Controls.Add(others);

            //Label Interested in job
            job.Text = "Are you interested in Full time Job? ";
            job.AutoSize = true; 
            job.Location = new Point(10, 165);
            //adding label
            Controls.Add(job);

            //checkbox job
            chkJob.Checked = true;
            chkJob.Location = new Point(185, 165);
            Controls.Add(chkJob);


            //submit button
            submit.Text = "Submit";
            submit.Size = new Size(50, 30);
            submit.Location = new Point(30, 200);
            //adding submit button
            Controls.Add(submit);

            //Clear button
            clear.Text = "Clear";
            clear.Size = new Size(50, 30);
            clear.Location = new Point(100, 200);
            //adding clear button
            Controls.Add(clear);

            //adding clear button event handler
            clear.Click += new EventHandler(onClickClearbtn);
            //adding submit button event handler
            submit.Click += new EventHandler(onClickSubmitbtn);
        }

        //method will clear the form
        void onClickClearbtn(object sender, EventArgs e)
        {
            enterName.Text = string.Empty;
            enterRoll.Text = string.Empty;
            enterCourse.Text = string.Empty;
            male.Checked = false;
            female.Checked = false;
            others.Checked = false;
            MessageBox.Show("Cleared Successfully!");
        }

        //method will clear the form and submit it
        void onClickSubmitbtn(object sender, EventArgs e)
        {
            enterName.Text = string.Empty;
            enterRoll.Text = string.Empty;
            enterCourse.Text = string.Empty;
            male.Checked = false;
            female.Checked = false;
            others.Checked = false;
            MessageBox.Show("Submitted Successfully!");
        }


    }
}
