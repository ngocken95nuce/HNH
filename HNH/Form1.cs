using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HNH
{
    public partial class Form1 : Form
    {
        double D0;
        double dentaHN = 0;
        double dentaDM = 0;
        double dentaDK = 0;
        double dentaAG = 0;
        double betaG = 0;
        double betaM = 0;
        double betaK = 0;
        double beta0 = 0;
        double gamma = 0;
        double[,] arrHN =
        {
            {0,0,0,0 },
            {5,10,9,0.3 },
            {10,24,17,0.7 },
            {15,46,24,1.2 },
            {20,80,28,1.7 },
            {25,124,31,2.2 },
            {30,168,34,2.9 },
            {35,205,36,3.9 },
            {40,239,37,5.1 },
            {45,280,37,7.1 }
        };
        double[,] arrDMDK =
        {
            { -1,0,6,9,12,15,18,21,24,27,30,33,36,39,42},
            {0,0,1,1.5,2,2.5,3,3.5,4,4.5,5,5.5,6,6.5,7 },
            { 10,0,1,1.5,2,2.5,3,3.5,4,4.5,5,5.5,6,6.5,7 },
            { 20,0,1,1.5,2,2.25,2.75,3.25,3.75,4.25,4.47,5.25,5.75,6,6.5 },
            { 30,0,0.75,1.25,1.75,2.25,2.5,3,3.5,4,4.25,4.75,5.25,5.76,6},
            {40,0,0.75,1.25,1.5,2,2.25,2.75,3,3.5,3.75,4.25,4.5,5,5.25 },
            {50,0,0.75,1,1.25,1.5,2,2.25,2.75,3,3.25,3.5,3.75,4.25,4.5},
            {  60,0,0.5,0.75,1,1.25,1.5,1.75,2,2.25,2.5,2.75,3,3.25,3.5},
            {70,0,0.25,0.5,0.75,0.75,1,1.25,1.25,1.5,1.75,2,2,2.25,2.5 },
            {80,0,0.25,0.25,0.25,0.5,0.5,0.5,0.75,0.75,0.75,1,1,1.25,1.25 },
            {90,0,1,1.5,2,2.5,3,3.5,4,4.5,5,5.5,6,6.5,7 },
            {100, 0,0.25,0.25,0.25,0.5,0.5,0.5,0.75,0.75,0.75,1,1,1.25,1.25},
            {110,0,0.25,0.5,0.75,0.75,1,1.25,1.25,1.5,1.75,2,2,2.25,2.5 },
            {  120,0,0.5,0.75,1,1.25,1.5,1.75,2,2.25,2.5,2.75,3,3.25,3.5},
             {130,0,0.75,1,1.25,1.5,2,2.25,2.75,3,3.25,3.5,3.75,4.25,4.5},
             {140,0,0.75,1.25,1.5,2,2.25,2.75,3,3.5,3.75,4.25,4.5,5,5.25 },
              { 150,0,0.75,1.25,1.75,2.25,2.5,3,3.5,4,4.25,4.75,5.25,5.76,6},
               { 160,0,1,1.5,2,2.25,2.75,3.25,3.75,4.25,4.47,5.25,5.75,6,6.5 },
                { 170,0,1,1.5,2,2.5,3,3.5,4,4.5,5,5.5,6,6.5,7 },
                {180,0,1,1.5,2,2.5,3,3.5,4,4.5,5,5.5,6,6.5,7 }
        };

        double[,] arrgocgio = {
            {0,5,55,60,65,120,125,180,185,240,245,300,305,360 ,-1,-1,-1,-1},
            { 10,50,70,110,130,170,190,230,250,290,310,350,-1,-1 ,-1,-1,-1,-1},
            {15,45,75,105,135,165,195,225,255,285,315,345,-1,-1 ,-1,-1,-1,-1 },
            { 20,40,80,100,140,160,200,220,260,280,320,340,-1,-1 ,-1,-1,-1,-1},
            {25,30,35,85,90,95,145,150,155,205,210,215,265,270,275,325,330,335}
        };

        double[,] arrD0VG =
        {
            {-1, 0,5,10,15,20,25,30,35,40,45,-1},
            {0,0,0,0,0,0,0,0,0,0,0,0 },
            { 0,0,0,0,0,0,0,0.25,0.25,0.25,0.5,5},
            {0,0,0,0,0,0.25,0.25,0.5,0.5,0.75,1,10 },
            {0,0,0,0,0,0.25,0.25,0.5,0.75,1,1.5,15 },
            {0,0,0,0.25,0.25,0.5,0.75,1,1.5,1.5,1.75,20 },
            {0,0,0,0.25,0.25,0.5,0.75,1,1.5,1.5,1.75,25 },
            {1,0,0,0,0,0,0,0,0,0,0,0 },
            {1,0,0,0,0,0,0,0.25,0.25,0.25,0.5,5 },
            {1,0,0,0,0,0.25,0.25,0.5,0.5,0.75,1,10 },
            {1,0,0,0,0,0.25,0.25,0.5,0.5,0.75,1,15 },
            {1,0,0,0,0,0.25,0.25,0.5,0.75,1,1.5,20 },
            {1,0,0,0,0,0.25,0.25,0.5,0.75,1,1.5,25 },
            {2,0,0,0,0,0,0,0,0,0,0,0 },
            {2,0,0,0,0,0,0,0,0,0,0,5 },
            {2,0,0,0,0,0,0,0,0,0,0,10 },
            {2,0,0,0,0,0,0,0,0,0,0,15 },
            {2,0,0,0,0,0,0,0,0,0,0,20 },
            {2,0,0,0,0,0,0,0,0,0,0,25 },
            {3,0,0,0,0,0,0,0,0,0,0,0 },
            {3,0,0,0,0,0,0,-0.25,-0.25,-0.25,-0.5,5 },
            {3,0,0,0,0,-0.25,-0.25,-0.5,-0.5,-0.75,-1,10 },
            {3,0,0,0,0,-0.25,-0.25,-0.5,-0.5,-0.75,-1,15 },
            {3,0,0,0,0,-0.25,-0.25,-0.5,-0.75,-1,-1.5,20 },
            {3,0,0,0,0,-0.25,-0.25,-0.5,-0.75,-1,-1.5,25 },
            {4,0,0,0,0,0,0,0,0,0,0,0 },
            {4,0,0,0,0,0,0,-0.25,-0.25,-0.25,-0.5,5 },
            {4,0,0,0,0,-0.25,-0.25,-0.5,-0.5,-0.75,-1,10 },
            {4,0,0,0,0,-0.25,-0.25,-0.5,-0.5,-0.75,-1,15 },
            {4,0,0,0,0,-0.25,-0.25,-0.5,-0.75,-1,-1.5,20 },
            {4,0,0,0,0,-0.25,-0.25,-0.5,-0.75,-1,-1.5,25 },
            {5,0,0,0,0,0,0,0,0,0,0,0 },
            {5,0,0,0,0,0,0,-0.25,-0.25,-0.25,-0.5,5 },
            {5,0,0,0,0,-0.25,-0.25,-0.5,-0.5,-0.75,-1,10 },
            {5,0,0,0,0,-0.25,-0.25,-0.5,-0.75,-1,-1.5,15 },
            {5,0,0,-0.25,-0.25,-0.5,-0.75,-1,-1.5,-1.5,-1.75,20 },
            {5,0,0,-0.25,-0.25,-0.5,-0.75,-1,-1.5,-1.5,-1.75,25 }
        };

        double[,] tdanbay = {
            {5,0},
            {10,0 },
            {15,0.1 },
            {20,0.1 },
            {25,0.1 },
            {30,0.2 },
            {35,0.2 },
            {40,0.4 },
            {45,0.3 }
        };

        double[,] arrgocgio_goc =
        {
            {0,30,60,90,120,150,180,210,240,270,300,330,360,-1,-1,-1,-1,-1 },
            {5,25,65,85,125,145,185,205,245,265,305,325,-1,-1,-1,-1,-1,-1 },
            {35,55,95,115,155,175,215,235,275,295,335,-1,-1,-1,-1,-1,-1,-1},
            {10,15,20,70,80,130,140,190,200,250,260,310,320,75,135,195,255,315 },
            {40,50,100,110,160,170,45,105,165,220,225,230,280,285,340,345,-1,-1 }
        };

        double[,] arrDOVG_goc =
        {
            {-1, 0,5,10,15,20,25,30,35,40,45,-1},
            {0,0,0,0,0,0,0,0,0,0,0,0 },
            {0,0,0,0,0,0,0,0,0,0,0,5 },
            {0,0,0,0,0,0,0,0,0,0,0,10 },
            {0,0,0,0,0,0,0,0,0,0,0,15 },
            {0,0,0,0,0,0,0,0,0,0,0,20 },
            {0,0,0,0,0,0,0,0,0,0,0,25 },
            {1,0,0,0,0,0,0,0,0,0,0,0 },
            {1,0,0,-1,-2,-2,-3,-4,-5,-6,-7,5 },
            {1,0,0,-1,-2,-2,-3,-4,-5,-6,-7,10 },
            {1,0,-1,-2,-3,-5,-6,-8,-10,-13,-15,15 },
            {1,0,-1,-2,-3,-5,-6,-8,-10,-13,-15,20 },
            {1,0,-1,-3,-5,-7,-10,-13,-16,-19,-22,25 },
            {2,0,0,0,0,0,0,0,0,0,0,0 },
            {2,0,0,1,2,2,3,4,5,6,7,5 },
            {2,0,0,1,2,2,3,4,5,6,7,10 },
            {2,0,1,2,3,5,6,8,10,13,15,15 },
            {2,0,1,2,3,5,6,8,10,13,15,20 },
            {2,0,1,3,5,7,10,13,16,19,22,25 },
            {3,0,0,0,0,0,0,0,0,0,0,0 },
            {3,0,0,-1,-2,-2,-3,-4,-5,-6,-7,5 },
            {3,0,-1,-2,-3,-5,-6,-8,-10,-13,-15,10 },
            {3,0,-1,-3,-5,-7,-10,-13,-16,-19,-22,15 },
            {3,0,-2,-4,-6,-9,-13,-17,-21,-25,-29,20 },
            {3,0,-2,-4,-6,-9,-13,-17,-21,-25,-29,25 },
            {4,0,0,0,0,0,0,0,0,0,0,0 },
            {4,0,0,1,2,2,3,4,5,6,7,5 },
            {4,0,1,2,3,5,6,8,10,13,15,10 },
            {4,0,1,2,3,5,6,8,10,13,15,15 },
            {4,0,2,4,6,9,13,17,21,25,29,20 },
            {4,0,2,4,6,9,13,17,21,25,29,20 }
        };

        double[,] arrGMVM =
        {
            {-1,0,6,9,12,15,18,21,24,27,30,33,36,39,42 },
            {0,0,3,4,6,7,9,10,12,13,14,16,17,19,20 },
            {10,0,0,1,1,1,2,2,2,2,2,3,3,3,4 },
            {20,0,1,1,2,2,3,3,4,4,5,5,6,6,7 },
            {30,0,1,2,3,4,4,5,6,6,7,8,9,9,10 },
            {40,0,2,3,4,5,6,7,7,8,9,10,11,12,13 },
            {50,0,2,3,4,6,7,8,9,10,11,12,13,14,15 },
            {60,0,2,4,5,6,8,9,10,11,12,14,15,16,17 },
            {70,0,3,4,5,7,8,9,11,12,13,15,16,17,19 },
            {80,0,3,4,6,7,9,10,11,13,14,16,17,18,20 },
            {90,0,3,4,6,7,9,10,12,13,14,16,17,19,20 },
            {100,0,3,4,6,7,9,10,11,13,14,16,17,18,20 },
            {110,0,3,4,5,7,8,9,11,12,13,15,16,17,19 },
            {120,0,2,4,5,6,8,9,10,11,12,14,15,16,17 },
            {130,0,2,3,4,6,7,8,9,10,11,12,13,14,15 },
            {140,0,2,3,4,5,6,7,7,8,9,10,11,12,13 },
            {150,0,1,2,3,4,4,5,6,6,7,8,9,9,10 },
            {160,0,1,1,2,2,3,3,4,4,5,5,6,6,7 },
            {170,0,0,1,1,1,2,2,2,2,2,3,3,3,4 },
            {180,0,3,4,6,7,9,10,12,13,14,16,17,19,20 }
        };

        double[] arrGKVKD0_goc = { 0,15,30,45,60,90};

        double[,] arrGKVKD0 =
        {
            {-1,0,6,12,18,24,30,36,42,48, -1},
            {0,0,0,0,0,0,0,0,0,0,0 },
            {0,0,0,0,0,0,0,0,0,0,5 },
            {0,0,-1,-1,-1,-1,-1,-1,-1,-1,10 },
            {0,0,-1,-1,-1,-1,-1,-1,-1,-1,15 },
            {0,-2,-2,-2,-2,-2,-2,-2,-2,-2,20 },
            {0,-2,-2,-2,-2,-2,-2,-2,-2,-2,25 },
            {0,-3,-3,-3,-3,-3,-3,-3,-3,-3,30 },
            {0,-4,-4,-4,-4,-4,-4,-4,-4,-4,35 },
            {0,-5,-5,-5,-5,-5,-5,-5,-5,-5,40 },
            {0,-7,-7,-7,-7,-7,-7,-7,-7,-7,45 },
            {15,0,0,0,0,0,0,0,0,0,0 },
            {15,0,1,1,2,3,4,5,6,6,5 },
            {15,0,0,1,2,3,4,5,6,7,10 },
            {15,0,0,1,2,3,4,5,6,7,15 },
            {15,0,-1,1,2,3,4,5,6,7,20 },
            {15,0,-1,0,2,3,4,5,7,8,25 },
            {15,0,-1,0,1,3,4,6,7,8,30 },
            {15,0,-3,-2,0,2,4,5,7,9,35 },
            {15,0,-3,-2,0,2,4,5,7,9,40 },
            {15,0,-5,-3,-1,1,3,4,6,8,45 },
            {30,0,0,0,0,0,0,0,0,0,0 },
            {30,0,1,3,4,6,8,9,11,12,5 },
            {30,0,1,3,5,6,8,10,12,13,10 },
            {30,0,1,3,5,6,8,10,12,14,15 },
            {30,0,0,3,5,7,9,11,13,16,20 },
            {30,0,0,3,5,7,10,12,15,17,25 },
            {30,0,0,3,5,8,11,14,16,19,30 },
            {30,0,-1,2,5,8,11,14,17,20,35 },
            {30,0,-2,2,5,8,11,15,18,22,40 },
            {30,0,-3,0,5,8,11,15,19,22,45 },
            {45,0,0,0,0,0,0,0,0,0,0 },
            {45,0,2,4,6,9,11,13,16,18,5 },
            {45,0,2,4,7,9,12,14,17,19,10 },
            {45,0,2,4,7,10,12,15,18,21,15 },
            {45,0,1,4,7,10,14,17,20,23,20 },
            {45,0,1,5,8,11,15,18,22,25,25 },
            {45,0,1,5,8,12,16,20,24,28,30 },
            {45,0,0,5,9,13,18,22,26,31,35 },
            {45,0,0,4,9,14,19,24,28,33,40 },
            {45,0,-2,3,9,14,19,24,29,34,45 },
            {60,0,0,0,0,0,0,0,0,0,0 },
            {60,0,2,5,8,11,14,16,19,22,5 },
            {60,0,2,5,8,11,14,18,21,24,10 },
            {60,0,2,5,9,12,15,19,22,26,15 },
            {60,0,2,6,9,13,17,21,24,28,20 },
            {60,0,2,6,10,15,19,23,27,31,25 },
            {60,0,2,7,11,16,21,26,30,35,30 },
            {60,0,1,7,12,17,23,28,33,38,35 },
            {60,0,1,7,12,18,24,30,36,42,40 },
            {60,0,-1,6,12,18,25,31,37,44,45 },
            {90,0,0,0,0,0,0,0,0,0,0 },
            {90,0,3,6,9,12,16,19,22,25,5 },
            {90,0,3,6,10,13,17,20,24,27,10 },
            {90,0,3,6,10,14,18,22,26,30,15 },
            {90,0,3,7,11,16,20,24,28,33,20 },
            {90,0,3,8,12,17,22,27,32,37,25 },
            {90,0,3,8,14,19,24,30,35,41,30 },
            {90,0,2,8,14,21,27,33,39,45,35 },
            {90,0,2,8,15,22,29,35,42,49,40 },
            {90,0,0,8,15,22,30,37,44,51,45 }
        };
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lblDb.Text = (dentaHN + dentaDM + dentaDK + dentaAG + D0).ToString() + " mét";
            lblbb.Text = (beta0 + betaG + betaK + betaM + gamma).ToString() + " li gác";
        }

        private void btndentaHN_Click(object sender, EventArgs e)
        {
            //khai báo biến
            double deltaVotong;
            int N = 0;
            int nn = 0;
            double x = 0;
            double ttb = 0;
            double Volh = 0;
            double y = 0;
            double k = 0;
            double kH = 0;
            double DV0 = 0;
            double Dpi = 0;
            double deltapi = 0;
            double deltaV0pi;
            double z = 0;
            bool check = true;

            //kiểm tra dữ liệu đầu vào
            if (check && !double.TryParse(txtd0.Text, out D0))
            {
                MessageBox.Show("Giá trị nhập vào của D0 phải là số");
                txtd0.Focus();
                txtd0.Text = "";
                check = false;
            }

            if (check && (D0 > 45 || D0 < 0))
            {
                MessageBox.Show("Giá trị D0 trong khoảng 0 - 45");
                txtd0.Focus();
                txtd0.Text = "";
                check = false;
            }

            if (check && !int.TryParse(txtN.Text, out N))
            {
                MessageBox.Show("Giá trị nhập vào của N phải là số");
                txtN.Focus();
                txtN.Text = "";
                check = false;
            }

            if (check && !double.TryParse(txtx.Text, out x))
            {
                MessageBox.Show("Giá trị nhập vào của x phải là số");
                txtx.Focus();
                txtx.Text = "";
                check = false;
            }

            if (check && !int.TryParse(txtnn.Text, out nn))
            {
                MessageBox.Show("Giá trị nhập vào của n phải là số");
                txtnn.Focus();
                txtnn.Text = "";
                check = false;
            }

            if (check && !double.TryParse(txtVolh.Text, out Volh))
            {
                MessageBox.Show("Giá trị nhập vào của Volh phải là số");
                txtVolh.Focus();
                txtVolh.Text = "";
                check = false;
            }

            if (check && !double.TryParse(txtk.Text, out k))
            {
                MessageBox.Show("Giá trị nhập vào của k phải là số");
                txtk.Focus();
                txtk.Text = "";
                check = false;
            }
            if (check && !double.TryParse(txtkh.Text, out kH))
            {
                MessageBox.Show("Giá trị nhập vào của kH phải là số");
                txtkh.Focus();
                txtkh.Text = "";
                check = false;
            }
            if (check && !double.TryParse(txtdentapi.Text, out deltapi))
            {
                MessageBox.Show("Giá trị nhập vào của ΔΠ phải là số");
                txtdentapi.Focus();
                txtdentapi.Text = "";
                check = false;
            }

            if (check && !double.TryParse(txtttb.Text, out ttb))
            {
                MessageBox.Show("Giá trị nhập vào của Ttb phải là số");
                txtttb.Focus();
                txtttb.Text = "";
                check = false;
            }
            //tính toán
            if (check)
            {
                deltaVotong = N * x / nn + 0.001 * (ttb - 15) + Volh;
                for (int i = 0; i < arrHN.GetLength(0) - 1; i++)
                {
                    if (D0 >= arrHN[i, 0] && D0 <= arrHN[i + 1, 0])
                    {
                        double tl = 0 ;
                        if (D0 - arrHN[i, 0] != 0)
                        {
                            tl = (arrHN[i + 1, 0] - D0) / (D0 - arrHN[i, 0]);
                        }
                        y = (arrHN[i + 1, 2] + tl * arrHN[i, 2]) / (1 + tl);
                    }
                }
                DV0 = deltaVotong * y;
                deltaV0pi = k * deltapi * kH;
                for (int i = 0; i < arrHN.GetLength(0) - 1; i++)
                {
                    if (D0 >= arrHN[i, 0] && D0 <= arrHN[i + 1, 0])
                    {
                        double tl=0;
                        if (D0 - arrHN[i, 0] != 0)
                        {
                            tl = (arrHN[i + 1, 0] - D0) / (D0 - arrHN[i, 0]);
                        }
                        z = (arrHN[i + 1, 1] + tl * arrHN[i, 1]) / (1 + tl);
                    }
                }
                Dpi = D0 * deltaV0pi / z;
                dentaHN = Math.Round(DV0 + Dpi, 2);
                lbldentaHN.Text = " = " + dentaHN + " mét";
                lblDb.Text = (dentaHN + dentaDM + dentaDK + dentaAG + D0).ToString() + " mét";
            }
        }

        private void btndentaDM_Click(object sender, EventArgs e)
        {
            double GM = 0;
            double VM = 0;
            bool check = true;

            if (check && !double.TryParse(txtd0.Text, out D0))
            {
                MessageBox.Show("Giá trị nhập vào của D0 phải là số");
                txtd0.Focus();
                txtd0.Text = "";
                check = false;
            }
            if (check && (D0 > 45 || D0 < 0))
            {
                MessageBox.Show("Giá trị D0 trong khoảng 0 - 45");
                txtd0.Focus();
                txtd0.Text = "";
                check = false;
            }
            if (check && !double.TryParse(txtGM.Text, out GM))
            {
                MessageBox.Show("Giá trị nhập vào của GM phải là số");
                txtGM.Focus();
                txtGM.Text = "";
                check = false;
            }
            if (GM < 0 || GM > 180)
            {
                MessageBox.Show("Giá trị nhập vào trong khoảng 0 - 180 độ");
                txtGM.Text = "";
                txtGM.Focus();
                check = false;
            }
            if (check && !double.TryParse(txtVM.Text, out VM))
            {
                MessageBox.Show("Giá trị nhập vào của VM phải là số");
                txtVM.Focus();
                txtVM.Text = "";
                check = false;
            }
            if (VM < 0 || VM > 42)
            {
                MessageBox.Show("Giá trị nhập vào trong khoảng 0 - 42");
                txtVM.Text = "";
                txtVM.Focus();
                check = false;
            }

            if (check)
            {

                double[] tg = new double[arrDMDK.GetLength(0)];
                double tpi = 0;
                for (int j = 1; j < arrDMDK.GetLength(1) - 1; j++)
                {
                    if (arrDMDK[0, j] <= VM && arrDMDK[0, j + 1] > VM)
                    {
                        double tlgm=0;
                        if (VM - arrDMDK[0, j] != 0)
                        {
                            tlgm = (arrDMDK[0, j + 1] - VM) / (VM - arrDMDK[0, j]);
                        }
                        for (int i = 1; i < arrDMDK.GetLength(0); i++)
                        {
                            tg[i] = (arrDMDK[i, j + 1] + tlgm * arrDMDK[i, j]) / (1 + tlgm);
                        }
                    }
                }
                for (int i = 1; i < arrDMDK.GetLength(0) - 1; i++)
                {
                    if (arrDMDK[i, 0] <= GM && arrDMDK[i + 1, 0] > GM)
                    {
                        double tlvm=0;
                        if((GM - arrDMDK[i, 0]) != 0)
                        {
                            tlvm = (arrDMDK[i + 1, 0] - GM) / (GM - arrDMDK[i, 0]);
                        }
                        dentaDM = (tg[i + 1] + tlvm * tg[i]) / (1 + tlvm);
                    }
                }
                for (int i = 0; i < tdanbay.GetLength(0) - 1; i++)
                {
                    if (D0 >= tdanbay[i, 0] && D0 < tdanbay[i + 1, 0])
                    {
                        double tl = 0;
                        if(D0 - tdanbay[i, 0] != 0)
                        {
                            tl = (tdanbay[i + 1, 0] - D0) / (D0 - tdanbay[i, 0]);
                        }
                        tpi = (tdanbay[i + 1, 1] + tdanbay[i, 1]) / (1 + tl);
                    }
                }
                dentaDM = Math.Round(dentaDM * tpi * 182.5, 2);
                lblDM.Text = " = " + dentaDM.ToString() + " mét";
                lblDb.Text = (dentaHN + dentaDM + dentaDK + dentaAG + D0).ToString() + " mét";
            }
        }

        private void btndentaDK_Click(object sender, EventArgs e)
        {
            double GK = 0;
            double VK = 0;
            bool check = true;

            if (check && !double.TryParse(txtd0.Text, out D0))
            {
                MessageBox.Show("Giá trị nhập vào của D0 phải là số");
                txtd0.Focus();
                txtd0.Text = "";
                check = false;
            }
            if (check && (D0 > 45 || D0 < 0))
            {
                MessageBox.Show("Giá trị D0 trong khoảng 0 - 45");
                txtd0.Focus();
                txtd0.Text = "";
                check = false;
            }
            if (check && !double.TryParse(txtGK.Text, out GK))
            {
                MessageBox.Show("Giá trị nhập vào của GK phải là số");
                txtGK.Focus();
                txtGK.Text = "";
                check = false;
            }
            if (GK < 0 || GK > 180)
            {
                MessageBox.Show("Giá trị nhập vào trong khoảng 0 - 180 độ");
                txtGK.Text = "";
                txtGK.Focus();
                check = false;
            }
            if (check && !double.TryParse(txtVK.Text, out VK))
            {
                MessageBox.Show("Giá trị nhập vào của VK phải là số");
                txtVK.Focus();
                txtVK.Text = "";
                check = false;
            }
            if (VK < 0 || VK > 42)
            {
                MessageBox.Show("Giá trị nhập vào trong khoảng 0 - 42");
                txtVK.Text = "";
                txtVK.Focus();
                check = false;
            }
            if (check)
            {
                double[] tg = new double[arrDMDK.GetLength(0)];
                double tpi = 0;
                for (int j = 1; j < arrDMDK.GetLength(1)-1; j++)
                {
                    if (arrDMDK[0, j] <= VK && arrDMDK[0, j + 1] > VK)
                    {
                        double tlgm = 0;
                        if(VK - arrDMDK[0, j]!=0)
                        {
                            tlgm = (arrDMDK[0, j + 1] - VK) / (VK - arrDMDK[0, j]);
                        }
                        for (int i = 1; i < arrDMDK.GetLength(0)-1; i++)
                        {
                            tg[i] = (arrDMDK[i, j + 1] + tlgm * arrDMDK[i, j]) / (1 + tlgm);
                        }
                    }
                }
                for (int i = 1; i < arrDMDK.GetLength(0)-1; i++)
                {
                    if (arrDMDK[i, 0] <= GK && arrDMDK[i + 1, 0] > GK)
                    {
                        double tlvm = 0;
                        if (GK - arrDMDK[i, 0] != 0)
                        {
                            tlvm = (arrDMDK[i + 1, 0] - GK) / (GK - arrDMDK[i, 0]);
                        }
                        dentaDK = (tg[i + 1] + tlvm * tg[i]) / (1 + tlvm);
                    }

                }
                for (int i = 0; i < tdanbay.GetLength(0)-1; i++)
                {
                    if (D0 >= tdanbay[i, 0] && D0 < tdanbay[i + 1, 0])
                    {
                        double tl = 0;
                        if(D0 - tdanbay[i, 0] != 0)
                        {
                            tl = (tdanbay[i + 1, 0] - D0) / (D0 - tdanbay[i, 0]);
                        }
                        tpi = (tdanbay[i + 1, 1] + tdanbay[i, 1]) / (1 + tl);
                    }
                }
                dentaDK = Math.Round(dentaDK * tpi * 182.5, 2);
                lblDK.Text = " = " + dentaDK.ToString()+" mét";
                lblDb.Text = (dentaHN + dentaDM + dentaDK + dentaAG + D0).ToString() + " mét";
            }
        }

        private void btndentaDG_Click(object sender, EventArgs e)
        {
            bool check = true;
            double AG = 0;
            double VG = 0;

            if (check && !double.TryParse(txtd0.Text, out D0))
            {
                MessageBox.Show("Giá trị nhập vào của D0 phải là số");
                txtd0.Focus();
                txtd0.Text = "";
                check = false;
            }
            if (check && (D0 > 45 || D0 < 0))
            {
                MessageBox.Show("Giá trị D0 trong khoảng 0 - 45");
                txtd0.Focus();
                txtd0.Text = "";
                check = false;
            }

            if (check && !double.TryParse(txtAG.Text, out AG))
            {
                MessageBox.Show("Giá trị nhập vào của AG phải là số");
                txtAG.Focus();
                txtAG.Text = "";
                check = false;
            }

            if (check && AG < 0 || AG > 360)
            {
                MessageBox.Show("Giá trị nhập vào trong khoảng 0 - 360 độ");
                txtAG.Text = "";
                txtAG.Focus();
                check = false;
            }

            if (check && !double.TryParse(txtVG.Text, out VG))
            {
                MessageBox.Show("Giá trị nhập vào của VG phải là số");
                txtVG.Focus();
                txtVG.Text = "";
                check = false;
            }

            if (check && VG < 0 || VG > 25)
            {
                MessageBox.Show("Giá trị nhập vào trong khoảng 0 - 25");
                txtVG.Text = "";
                txtVG.Focus();
                check = false;
            }
            if (check)
            {
                //tính theo góc
                int rowmin = 0;
                int rowmax = 0;
                double sb = -1;
                double sl = -1;
                for (int i = 0; i < arrgocgio.GetLength(0); i++)
                {
                    for (int j = 0; j < arrgocgio.GetLength(1); j++)
                    {
                        if (arrgocgio[i, j] >= 0)
                        {
                            if ((AG - arrgocgio[i, j]) >= 0)
                            {
                                if (sb < 0)
                                {
                                    sb = AG - arrgocgio[i, j];
                                }
                                else
                                {
                                    if (sb >= (AG - arrgocgio[i, j]))
                                    {
                                        sb = AG - arrgocgio[i, j];
                                        rowmin = i;
                                    }
                                }
                            }
                            if ((arrgocgio[i, j] - AG) >= 0)
                            {
                                {
                                    if (sl < 0)
                                    {
                                        sl = arrgocgio[i, j] - AG;
                                    }
                                    else
                                    {
                                        if (sl >= (arrgocgio[i, j] - AG))
                                        {
                                            sl = arrgocgio[i, j] - AG;
                                            rowmax = i;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                double[,] tg = new double[7, 12];
                int k = 0;// số dòng của bảng trung gian theo AG
                for (int i = 0; i < arrD0VG.GetLength(0); i++)
                {
                    if (arrD0VG[i, 0] == rowmin || i == 0)
                    {
                        for (int j = 0; j < arrD0VG.GetLength(1); j++)
                        {
                            tg[k, j] = arrD0VG[i, j];
                        }
                        k++;
                    }
                }
                double tlgoc = 0;
                if (sb != 0)
                {
                    tlgoc = sl / sb;
                }
                int z = 1;
                for (int i = 1; i < arrD0VG.GetLength(0); i++)
                {
                    if (arrD0VG[i, 0] == rowmax)
                    {
                        for (int j = 0; j < arrD0VG.GetLength(1); j++)
                        {
                            tg[z, j] = (arrD0VG[i, j] + tlgoc * arrD0VG[z, j]) / (1 + tlgoc);
                        }
                        z++;
                    }
                }
                //tính theo VG
                double[] tgv = new double[12];
                for (int i = 1; i < k-1; i++)
                {
                    if (VG >= tg[i, 11] && VG <= tg[i + 1, 11])
                    {
                        double tlvantoc = 0;
                        if(VG - tg[i, 11] != 0)
                        {
                            tlvantoc = (tg[i + 1, 11] - VG) / (VG - tg[i, 11]);
                        }
                        for (int j = 0; j < arrD0VG.GetLength(1)-1; j++)
                        {
                            tgv[j] = (arrD0VG[i + 1, j] + tlvantoc * arrD0VG[i, j]) / (1 + tlvantoc);
                        }
                    }
                }
                //tính theo D0
                for (int i = 1; i < arrD0VG.GetLength(1) - 1; i++)
                {
                    if (D0 >= tgv[i] && D0 <= tgv[i + 1])
                    {
                        double tld = 0;
                        if(D0 - tgv[i] != 0)
                        {
                            tld = (tgv[i + 1] - D0) / (D0 - tgv[i]);
                        }
                        dentaAG = (tgv[i + 1] + tld * tgv[i]) / (1 + tld);
                    }
                }
                dentaAG = Math.Round(dentaAG * 182.5, 2);
                lblDG.Text = " = "+dentaAG.ToString()+" mét";
                lblDb.Text = (dentaHN + dentaDM + dentaDK + dentaAG + D0).ToString() + " mét";
            }
        }

        private void btngamma_Click(object sender, EventArgs e)
        {
            bool check = true;


            if (check && !double.TryParse(txtd0.Text, out D0))
            {
                MessageBox.Show("Giá trị nhập vào của D0 phải là số");
                txtd0.Focus();
                txtd0.Text = "";
                check = false;
            }
            if (check && (D0 > 45 || D0 < 0))
            {
                MessageBox.Show("Giá trị D0 trong khoảng 0 - 45");
                txtd0.Focus();
                txtd0.Text = "";
                check = false;
            }

            if (check && !double.TryParse(txtbeta0.Text, out beta0))
            {
                MessageBox.Show("Giá trị nhập vào của β0 phải là số");
                txtbeta0.Focus();
                txtbeta0.Text = "";
                check = false;
            }

            if (check) { 
                for (int i=0; i < arrHN.GetLength(0) - 1; i++)
                {
                    if(D0>=arrHN[i,0] && D0 < arrHN[i + 1, 0])
                    {
                        double tl = 0;
                        if (D0 - arrHN[i, 0] != 0)
                        {
                            tl = (arrHN[i + 1, 0] - D0) / (D0 - arrHN[i, 0]);
                        }
                        gamma = (arrHN[i + 1, 3] + tl * arrHN[i, 3]) / (1 + tl);
                    }
                }
                lblgamma.Text = " = " + gamma + " li gác";
                lblbb.Text = (beta0 + betaG + betaK + betaM + gamma).ToString() + " li gác";
            }
        }

        private void btnbetaM_Click(object sender, EventArgs e)
        {
            bool check = true;
            double VM = 0;
            double GM = 0;
            if (check && !double.TryParse(txtVM.Text, out VM))
            {
                MessageBox.Show("Giá trị nhập vào của VM phải là số");
                txtVM.Focus();
                txtVM.Text = "";
                check = false;
            }

            if (check && VM < 0 || VM > 42)
            {
                MessageBox.Show("Giá trị nhập vào trong khoảng 0 - 42");
                txtVM.Text = "";
                txtVM.Focus();
                check = false;
            }

            if (check && !double.TryParse(txtGM.Text, out GM))
            {
                MessageBox.Show("Giá trị nhập vào của AG phải là số");
                txtGM.Focus();
                txtGM.Text = "";
                check = false;
            }

            if (check && GM < 0 || GM > 180)
            {
                MessageBox.Show("Giá trị nhập vào trong khoảng 0 - 180 độ");
                txtGM.Text = "";
                txtGM.Focus();
                check = false;
            }

            if (check)
            {
                double[,] tg=new double[2, arrGMVM.GetLength(1)];
                for(int j = 0; j < arrGMVM.GetLength(1); j++)
                {
                    tg[0, j] = arrGMVM[0, j];
                }
                for(int i = 1; i < arrGMVM.GetLength(0) - 1; i++)
                {
                    if(GM>=arrGMVM[i,0] && GM <= arrGMVM[i + 1, 0])
                    {
                        double tlgm = 0;
                        if (GM - arrGMVM[i, 0] != 0)
                        {
                            tlgm = (arrGMVM[i + 1, 0] - GM) / (GM - arrGMVM[i, 0]);
                        }
                        for(int j = 0; j < arrGMVM.GetLength(1); j++)
                        {
                            tg[1, j] = (arrGMVM[i + 1, j] + tlgm * arrGMVM[i, j]) / (1 + tlgm);
                        }
                    }
                }

                for(int j = 1; j < arrGMVM.GetLength(1)-1; j++)
                {
                    if(VM>=tg[0,j] && VM <= tg[0, j + 1])
                    {
                        double tlvm = 0;
                        if (VM - tg[0, j] != 0)
                        {
                            tlvm = (tg[0, j + 1] - VM) / (VM - tg[0, j]);
                        }
                        betaM = (tg[1, j + 1] + tlvm * tg[1, j]) / (1 + tlvm);
                    }
                }
                betaM = Math.Round(betaM, 2);
                lblbetaM.Text = " = " + betaM.ToString() + " li gác";
                lblbb.Text = (beta0 + betaG + betaK + betaM + gamma).ToString() + " li gác";
            }
        }

        private void btnbetaG_Click(object sender, EventArgs e)
        {
            bool check = true;
            double AG = 0;
            double VG = 0;
            if (check && !double.TryParse(txtd0.Text, out D0))
            {
                MessageBox.Show("Giá trị nhập vào của D0 phải là số");
                txtd0.Focus();
                txtd0.Text = "";
                check = false;
            }
            if (check && (D0 > 45 || D0 < 0))
            {
                MessageBox.Show("Giá trị D0 trong khoảng 0 - 45");
                txtd0.Focus();
                txtd0.Text = "";
                check = false;
            }

            if (check && !double.TryParse(txtAG.Text, out AG))
            {
                MessageBox.Show("Giá trị nhập vào của AG phải là số");
                txtAG.Focus();
                txtAG.Text = "";
                check = false;
            }

            if (check && AG < 0 || AG > 360)
            {
                MessageBox.Show("Giá trị nhập vào trong khoảng 0 - 360 độ");
                txtAG.Text = "";
                txtAG.Focus();
                check = false;
            }

            if (check && !double.TryParse(txtVG.Text, out VG))
            {
                MessageBox.Show("Giá trị nhập vào của VG phải là số");
                txtVG.Focus();
                txtVG.Text = "";
                check = false;
            }

            if (check && VG < 0 || VG > 25)
            {
                MessageBox.Show("Giá trị nhập vào trong khoảng 0 - 25");
                txtVG.Text = "";
                txtVG.Focus();
                check = false;
            }
            if (check)
            {
                //tính theo góc
                int rowmin = 0;
                int rowmax = 0;
                double sb = -1;
                double sl = -1;
                for (int i = 0; i < arrgocgio_goc.GetLength(0); i++)
                {
                    for (int j = 0; j < arrgocgio.GetLength(1); j++)
                    {
                        if (arrgocgio_goc[i, j] >= 0)
                        {
                            if ((AG - arrgocgio_goc[i, j]) >= 0)
                            {
                                if (sb < 0)
                                {
                                    sb = AG - arrgocgio_goc[i, j];
                                }
                                else
                                {
                                    if (sb >= (AG - arrgocgio_goc[i, j]))
                                    {
                                        sb = AG - arrgocgio_goc[i, j];
                                        rowmin = i;
                                    }
                                }
                            }
                            if ((arrgocgio_goc[i, j] - AG) >= 0)
                            {
                                {
                                    if (sl < 0)
                                    {
                                        sl = arrgocgio_goc[i, j] - AG;
                                    }
                                    else
                                    {
                                        if (sl >= (arrgocgio_goc[i, j] - AG))
                                        {
                                            sl = arrgocgio_goc[i, j] - AG;
                                            rowmax = i;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                double[,] tg = new double[7, 12];
                int k = 0;// số dòng của bảng trung gian theo AG
                for (int i = 0; i < arrDOVG_goc.GetLength(0); i++)
                {
                    if (arrDOVG_goc[i, 0] == rowmin || i == 0)
                    {
                        for (int j = 0; j < arrDOVG_goc.GetLength(1); j++)
                        {
                            tg[k, j] = arrDOVG_goc[i, j];
                        }
                        k++;
                    }
                }
                double tlgoc = 0;
                if (sb != 0)
                {
                    tlgoc = sl / sb;
                }
                int z = 1;
                for (int i = 1; i < arrDOVG_goc.GetLength(0); i++)
                {
                    if (arrDOVG_goc[i, 0] == rowmax)
                    {
                        for (int j = 0; j < arrDOVG_goc.GetLength(1)-1; j++)
                        {
                            tg[z, j] = (arrDOVG_goc[i, j] + tlgoc * tg[z,j]) / (1 + tlgoc);
                        }
                        z++;
                    }
                }
                //tính theo VG
                double[,] tgv = new double[2,12];
                for (int j = 0; j < arrDOVG_goc.GetLength(1); j++)
                {
                    tgv[0, j] = tg[0, j];
                }
                for (int i = 0; i < k-1; i++)
                {
                    if (VG >= tg[i, 11] && VG <= tg[i + 1, 11])
                    {
                        double tlvantoc = 0;
                        if (VG - tg[i, 11] != 0)
                        {
                            tlvantoc = (tg[i + 1, 11] - VG) / (VG - tg[i, 11]);
                        }
                        for (int j = 0; j < arrDOVG_goc.GetLength(1); j++)
                        {
                            tgv[1,j] = (tg[i + 1, j] + tlvantoc * tg[i, j]) / (1 + tlvantoc);
                        }
                    }
                }
                //tính theo D0
                for (int i = 1; i < tgv.GetLength(1)-1; i++)
                {
                    if (D0 >= tgv[0,i] && D0 <= tgv[0,i + 1])
                    {
                        double tld = 0;
                        if (D0 - tgv[0, i] != 0)
                        {
                            tld = (tgv[0, i + 1] - D0) / (D0 - tgv[0, i]);
                        }
                        betaG = (tgv[1,i + 1] + tld * tgv[1,i]) / (1 + tld);
                    }
                }
                betaG = Math.Round(betaG, 2);
                lblbetaG.Text = " = "+betaG.ToString()+" li gác";
                lblbb.Text = (beta0 + betaG + betaK + betaM + gamma).ToString() + " li gác";
            }
        }

        private void btnbetaK_Click(object sender, EventArgs e)
        {
            bool check = true;
            double GK = 0;
            double VK = 0;
            if (check && !double.TryParse(txtd0.Text, out D0))
            {
                MessageBox.Show("Giá trị nhập vào của D0 phải là số");
                txtd0.Focus();
                txtd0.Text = "";
                check = false;
            }
            if (check && (D0 > 45 || D0 < 0))
            {
                MessageBox.Show("Giá trị D0 trong khoảng 0 - 45");
                txtd0.Focus();
                txtd0.Text = "";
                check = false;
            }

            if (check && !double.TryParse(txtGK.Text, out GK))
            {
                MessageBox.Show("Giá trị nhập vào của GK phải là số");
                txtGK.Focus();
                txtGK.Text = "";
                check = false;
            }

            if (check && GK < 0 || GK > 90)
            {
                MessageBox.Show("Giá trị nhập vào trong khoảng 0 - 90 độ");
                txtGK.Text = "";
                txtGK.Focus();
                check = false;
            }

            if (check && !double.TryParse(txtVK.Text, out VK))
            {
                MessageBox.Show("Giá trị nhập vào của VK phải là số");
                txtVK.Focus();
                txtVK.Text = "";
                check = false;
            }

            if (check && VK < 0 || VK > 48)
            {
                MessageBox.Show("Giá trị nhập vào trong khoảng 0 - 48");
                txtVK.Text = "";
                txtVK.Focus();
                check = false;
            }

            if (check)
            {
                double min = 0;
                double max = 0;
                double tlgk = 0;
                for(int j = 0; j < arrGKVKD0_goc.Length-1; j++)
                {
                    if(GK>=arrGKVKD0_goc[j] && GK <= arrGKVKD0_goc[j + 1])
                    {
                        min = arrGKVKD0_goc[j];
                        max= arrGKVKD0_goc[j+1];
                        if(GK - min != 0)
                        {
                            tlgk = (max - GK) / (GK - min);
                        }
                    }
                }

                double[,] tg = new double[11, arrGKVKD0.GetLength(1)];
                for(int j = 0; j < arrGKVKD0.GetLength(1); j++)
                {
                    tg[0, j] = arrGKVKD0[0, j];
                }
                int k = 1;
                for(int i = 1; i < arrGKVKD0.GetLength(0); i++)
                {
                    if (arrGKVKD0[i, 0] == min)
                    {
                        for(int j = 0; j < arrGKVKD0.GetLength(1); j++)
                        {
                            tg[k, j] = arrGKVKD0[i, j];
                        }
                        k++;
                    }
                }
                int z = 1;
                for(int i = 1; i < arrGKVKD0.GetLength(0); i++)
                {
                    if (arrGKVKD0[i, 0] == max)
                    {
                        for(int j = 0; j < arrGKVKD0.GetLength(1); j++)
                        {
                            tg[z, j] = (arrGKVKD0[i, j] + tlgk * tg[z, j]) / (1 + tlgk);
                        }
                        z++;
                    }
                }

                double[,] tgvk = new double[2, arrGKVKD0.GetLength(1)];
                for(int j = 0; j < arrGKVKD0.GetLength(1); j++)
                {
                    tgvk[0, j] = arrGKVKD0[0, j];
                }
                for(int i = 1; i < tg.GetLength(0) - 1; i++)
                {
                    if(D0>=tg[i,10] && D0 <= tg[i + 1,10])
                    {
                        double tldo = 0;
                        if (D0 - tg[i, 10] != 0)
                        {
                            tldo = (tg[i + 1, 10] - D0) / (D0 - tg[i, 10]);
                        }
                        for(int j = 0; j < arrGKVKD0.GetLength(1); j++)
                        {
                            tgvk[1, j] = (tg[i + 1, j] + tldo * tg[i, j]) / (1 + tldo);
                        }
                    }
                }

                for(int j = 1; j < tgvk.GetLength(1) - 1; j++)
                {
                    if(VK>=tgvk[0,j] && VK <= tgvk[0,j + 1])
                    {
                        double tlm = 0;
                        if (VK - tgvk[0, 1] != 0)
                        {
                            tlm=(tgvk[0, j + 1] - VK) / (VK - tgvk[0, 1]);
                        }
                        betaK = (tgvk[1, j + 1] + tlm * tgvk[1, j]) / (1 + tlm);
                    }
                }
                betaK = Math.Round(betaK, 2);
                lblbetaK.Text = " = " + betaK + " li gác";
                lblbb.Text = (beta0 + betaG + betaK + betaM + gamma).ToString() + " li gác";
            }
        }
    }
}
