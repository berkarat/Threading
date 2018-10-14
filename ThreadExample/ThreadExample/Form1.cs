using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace ThreadExample
{
    public partial class Form1 : Form
    {
        Thread thread_1, thread_2, thread_3, thread_4, thread_5 ;


        System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer ();

        public Form1 ()
        {
            InitializeComponent ();
            thread_1=new Thread (new ThreadStart (t_1));
            thread_2=new Thread (new ThreadStart (t_2));
            thread_3=new Thread (new ThreadStart (t_3));
            thread_4=new Thread (new ThreadStart (t_4));
            thread_5=new Thread (new ThreadStart (t_5));


            Control.CheckForIllegalCrossThreadCalls=false;       // THREAD ÇAKIŞMASINI ENGELLER
            timer.Tick+=new EventHandler (Timer_Tick);
            timer.Interval=(1000); timer.Start ();
            timer.Enabled=true;


        }
        string Thread_State;
        private void button1_Click (object sender, EventArgs e)
        {
            

            thread_1.Start (); thread_1.Abort ();
            Thread_State= thread_1.ThreadState.ToString();
            Thread_State=thread_1.IsAlive.ToString ();
            thread_1.Join ();
            //thread_1.Join (300);   //300 ms kadar işlem yapar
            Console.WriteLine ("thread_1 bitti");
            label1.Text="thread_1 bitti";
            Thread.Sleep (2000);
            //thread_2.Start ();
            //thread_2.Join ();
            label1.Text="thread_2 bitti";
            Console.WriteLine ("thread_2 bitti");
            thread_3.Start ();
            thread_4.Start ();
        }

      

        private void t_1 ()
        {
            thread_5.Start ();

            for (int i = 0; i<=100; i++)
            {
                progressBar1.Value=i;
                Thread.Sleep (20);

            }


        }
        private void t_2 ()
        {
            for (int i = 0; i<=100; i++)
            {
                //  trackBar1.Value=i;
                progressBar2.Value=i;
                Thread.Sleep (20);

            }

        }
        private void t_3 ()
        {
            for (int i = 100; i>=0; i--)
            {
                //  trackBar1.Value=i;
                progressBar3.Value=i;
                Thread.Sleep (20);

            }
        }
        private void t_4 ()
        {

            for (int i = 0; i<=10; i++)
            {
                trackBar1.Value=i;

                Thread.Sleep (200);

            }


        }
        private void t_5 ()
        {

            for (int i = 0; i<=100; i++)
            {
                listBox1.Items.Add (i);

                Thread.Sleep (30);

            }


        }
        private void Timer_Tick (object sender, EventArgs e)
        {
            label2.Text=DateTime.Now.ToString ();
        }


    }
}
