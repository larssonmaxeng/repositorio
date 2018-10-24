using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Autodesk.Revit.DB.Architecture;
using Autodesk.Revit.UI.Selection;
using revitDB = Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using appRevit = Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB.Plumbing;
using Autodesk.Revit.DB.Structure;
using AcessoBancoDados;
using Negocios;
using ObjetoTransferencia;
using Funcoes;
using System.Runtime.InteropServices;
namespace Apresentacao
{
    public partial class FrmNuvemRevisao : Form
    {

        Color cor;
        public IntPtr TelaSelecionada { get; set; }
        public const int WM_LBUTTONDOWN = 0x201;
        public const int WM_WINDOWPOSCHANGING = 70;
        public const int WM_KEYDOWN = 0100;
        private bool continuar;
        public bool primeiroClick;
        public BSNuvemRevisao bsNuvemRevisao;
        public ACESSO_NUVEM_REVISAO acessoNuvemRevisao;
        public NBindingSource1 bsVistaAssociada;
        public ACESSO_VISTA_ASSOCIADA acessoVistaAssociada;
 
        public bool Continuar
        {
            get
            {
                return continuar;
            }
            set
            {
                continuar = value;
            }
        }

        private Autodesk.Revit.DB.Document uiDoc;
        private Autodesk.Revit.UI.UIApplication uiApp;
        public string dir;
        public FrmNuvemRevisao()
        {
            InitializeComponent();
            Continuar = false;

        }
        public VISTA_ASSOCIADA GetVISTA_ASSOCIADA(byte[] imagem)
        {
            VISTA_ASSOCIADA vista = new VISTA_ASSOCIADA();
            vista.IMAGEM = imagem;
            vista.INTEGER_VALUE = uiDoc.ActiveView.Id.IntegerValue;
            vista.NUVEM_REVISAO_ID = Convert.ToInt32(dataGridView1.CurrentRow.Cells[nameof(NUVEM_REVISAO.NUVEM_REVISAO_ID)].Value);
            if(uiDoc.ActiveView is revitDB.ViewPlan)
                if((uiDoc.ActiveView as revitDB.ViewPlan).LevelId!=null)
                    try
                    {
                        revitDB.Level level = uiDoc.GetElement((uiDoc.ActiveView as revitDB.ViewPlan).LevelId) as revitDB.Level;
                        vista.PAVIMENTO = level.Name;
                        vista.ELEVACAO = level.Elevation * 0.3048;

                    }
                    catch
                    {

                    }
            vista.TIPO_DE_VISTA = uiDoc.ActiveView.Name + "- " + uiDoc.ActiveView.ViewType.ToString();

            return vista;

        }
        public FrmNuvemRevisao(Autodesk.Revit.DB.Document iuiDoc, UIApplication iuiApp, string idir, string guid)
        {
            InitializeComponent();
            Continuar = false;

            acessoNuvemRevisao = new ACESSO_NUVEM_REVISAO(dir);
            bsNuvemRevisao = new BSNuvemRevisao(acessoNuvemRevisao);
            bsNuvemRevisao.DataSource = acessoNuvemRevisao.Selecionar(new NUVEM_REVISAO { MODELO_GUID_ID = guid });
            bsNuvemRevisao.CachedUpdates = false; 
            dataGridView1.DataSource = bsNuvemRevisao;

            acessoVistaAssociada = new ACESSO_VISTA_ASSOCIADA(dir);
            bsVistaAssociada = new NBindingSource1(acessoVistaAssociada);
            if (bsNuvemRevisao.Current != null)
            {
                object o = bsNuvemRevisao.Current.GetType().GetProperty(nameof(NUVEM_REVISAO.NUVEM_REVISAO_ID)).GetValue(bsNuvemRevisao.Current);
                if (o != null)
                {
                    int id;
                    if (int.TryParse(o.ToString(), out id))
                        bsVistaAssociada.DataSource = acessoVistaAssociada.Selecionar(new VISTA_ASSOCIADA { NUVEM_REVISAO_ID = id });
                }
            }
            bsVistaAssociada.CachedUpdates = false;
            dataGridView2.DataSource = bsVistaAssociada;
            bsNuvemRevisao.bsVistaAssociada = bsVistaAssociada;

            bindingNavigator1.BindingSource =bsNuvemRevisao;
            bindingNavigator3.BindingSource = bsVistaAssociada;


            uiDoc = iuiDoc;
            uiApp = iuiApp;
            dir = idir;
            chkHerdarVista.Checked = false;
            chkHerdarVista.Enabled = false;
            bsVistaAssociada.PositionChanged += new System.EventHandler(MostraImagem);
            MostraImagem(null, null);
        }
        public void MostraImagem(object sender, EventArgs e)
        {
            if (bsVistaAssociada == null) return;
            if (bsVistaAssociada.Current == null) return;
            object imagem = bsVistaAssociada.Current.GetType().GetProperty(nameof(VISTA_ASSOCIADA.IMAGEM)).GetValue(bsVistaAssociada.Current);
            
            if (imagem != null)
            {
                using (var stream = new System.IO.MemoryStream((byte[])imagem))
                {
                    pictureBox1.Image = Bitmap.FromStream(stream);
                }
            }
        }
        [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case 7:

                    break;

                case 160:
                    //    case 512:

                    /*if (Continuar)
                    {
                        Tela tela = new Tela();
                        IntPtr tela1 = tela.JanelaAPartirDoPonto(Cursor.Position);
                        Graphics g = Graphics.FromHwndInternal(tela1);
                        Pen pen = new Pen(Color.Red, 3);
                        pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
                        Rectangle r = tela.TamanhoDoHandle(tela1);
                        r.Inflate(-30, -5);
                        g.DrawRectangle(pen, 0, 0, r.Width, r.Height);
                        g.Flush();
                        Application.DoEvents();
                    }*/

                    break;

                case 134:
                    if (Continuar)
                    {
                        Tela tela = new Tela();
                        IntPtr tela1;
                        if (!chkHerdarVista.Checked)
                        {
                           tela1  = tela.JanelaAPartirDoPonto(Cursor.Position);
                        }
                        else
                        {
                            tela1 = TelaSelecionada;
                        }

                        Bitmap bmp = tela.RetornaImagemControle(tela1, tela.TamanhoDoHandle(tela1));
                        pictureBox1.Image = bmp;
                        ACESSO_VISTA_ASSOCIADA acesso = new ACESSO_VISTA_ASSOCIADA(dir);
                        VISTA_ASSOCIADA v = GetVISTA_ASSOCIADA(ConverterFotoParaByteArray(bmp));

                        new ACESSO_VISTA_ASSOCIADA(dir).Sincronizar(v, 3);
                        bsVistaAssociada.Refresh();
                        this.TopMost = false;
                        Continuar = false;
                        Opacity = 1;
                        BackColor = cor;
                        AllowTransparency = false;
                        TelaSelecionada = tela1;
                        chkHerdarVista.Enabled = true;

                        Application.DoEvents();
                    }
                    break;
                case WM_LBUTTONDOWN:
                    break;
                case WM_KEYDOWN:

                    break;
                case WM_WINDOWPOSCHANGING:
                    Cursor = Cursors.Hand;
                    break;
                default:

                    break;
            }
            base.WndProc(ref m);
        }


        private void btnMostrar_Click(object sender, EventArgs e)
        {
            int elemento = Convert.ToInt32(dataGridView1.CurrentRow.Cells["INTEGER_VALUE"].Value);
            revitDB.RevisionCloud nuvem = uiDoc.GetElement(new revitDB.ElementId(elemento)) as revitDB.RevisionCloud;
            revitDB.View view =uiDoc.GetElement( nuvem.OwnerViewId) as revitDB.View;
            uiApp.ActiveUIDocument.ActiveView = view;
            uiApp.ActiveUIDocument.ShowElements(nuvem);
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = NegocioRevit.Seleciona(uiDoc);
        }
        public void GerarImagem()
        {
           
           
            
        }
        private byte[] ConverterFotoParaByteArray(Bitmap b)
        {
            using (var stream = new System.IO.MemoryStream())
            {

                b.Save(stream, System.Drawing.Imaging.ImageFormat.Bmp);
                stream.Seek(0, System.IO.SeekOrigin.Begin);
                byte[] bArray = new byte[stream.Length];
                stream.Read(bArray, 0, System.Convert.ToInt32(stream.Length));
                return bArray;
            }
        }

        private void btnSalvarImagem_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.Hand;
            //cor = BackColor;
            //BackColor = Color.Fuchsia;
            //TransparencyKey = Color.Fuchsia;
            //AllowTransparency = true;

            Continuar = true;
            //TopMost = true;
            // WindowState = FormWindowState.Maximized;
            Opacity = 0.2;

        }

        
    }
    public class Tela
    {
        [DllImport("user32.dll", EntryPoint = "GetDC")]
        static extern IntPtr GetDC(IntPtr ptr);
        [DllImport("user32.dll", EntryPoint = "ReleaseDC")]
        static extern IntPtr ReleaseDC(IntPtr hWnd, IntPtr hDc);
        [DllImport("gdi32.dll", EntryPoint = "DeleteDC")]
        static extern IntPtr DeleteDC(IntPtr hDc);
        [DllImport("gdi32.dll", EntryPoint = "CreateCompatibleDC")]
        static extern IntPtr CreateCompatibleDC(IntPtr hdc);
        [DllImport("gdi32.dll", EntryPoint = "CreateCompatibleBitmap")]
        static extern IntPtr CreateCompatibleBitmap(IntPtr hdc, int nWidth, int nHeight);
        [DllImport("gdi32.dll", EntryPoint = "SelectObject")]
        static extern IntPtr SelectObject(IntPtr hdc, IntPtr bmp);
        [DllImport("gdi32.dll", EntryPoint = "BitBlt")]
        static extern bool BitBlt(IntPtr hdcDest, int xDest, int yDest, int wDest, int hDest, IntPtr hdcSource, int xSrc, int ySrc, int RasterOp);
        [DllImport("user32.dll", EntryPoint = "GetDesktopWindow")]
        static extern IntPtr GetDesktopWindow();
        [DllImport("gdi32.dll", EntryPoint = "DeleteObject")]
        static extern IntPtr DeleteObject(IntPtr hDc);
        [DllImport("user32.dll")]
        static extern IntPtr WindowFromPoint(POINT Point);
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool GetWindowRect(HandleRef hWnd, out RECT lpRect);

        const int SRCCOPY = 13369376;
        public struct SIZE
        {
            public int cx;
            public int cy;
        }
        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int Left;        // x position of upper-left corner
            public int Top;         // y position of upper-left corner
            public int Right;       // x position of lower-right corner
            public int Bottom;      // y position of lower-right corner
        }
        [StructLayout(LayoutKind.Sequential)]
        public struct POINT
        {
            public int X;
            public int Y;

            public POINT(int x, int y)
            {
                this.X = x;
                this.Y = y;
            }

            public POINT(System.Drawing.Point pt) : this(pt.X, pt.Y) { }

            public static implicit operator System.Drawing.Point(POINT p)
            {
                return new System.Drawing.Point(p.X, p.Y);
            }

            public static implicit operator POINT(System.Drawing.Point p)
            {
                return new POINT(p.X, p.Y);
            }
        }

        public Rectangle TamanhoDoHandle(IntPtr tela)
        {
            RECT rectWindows;
            HandleRef hWnd = new HandleRef(null, tela);
            GetWindowRect(hWnd, out rectWindows);
            Rectangle myRect = new Rectangle();
            myRect.X = rectWindows.Left;
            myRect.Y = rectWindows.Top;
            myRect.Width = rectWindows.Right - rectWindows.Left + 1;
            myRect.Height = rectWindows.Bottom - rectWindows.Top + 1;
            return myRect;
        }

        public IntPtr TelaPrincipalDoWindows()
        {
            return GetDesktopWindow();
        }
        public IntPtr JanelaAPartirDoPonto(Point ponto)
        {
            POINT point;
            point.X = ponto.X;
            point.Y = ponto.Y;
            return WindowFromPoint(point);
        }
        public Bitmap RetornaImagemControle(IntPtr controle, Rectangle area)
        {
            SIZE size;
            IntPtr hBitmap;

            IntPtr hDC = GetDC(controle);
            IntPtr hMemDC = CreateCompatibleDC(hDC);

            size.cx = area.Width - area.Left;
            size.cy = area.Bottom - area.Top;

            hBitmap = CreateCompatibleBitmap(hDC, size.cx, size.cy);



            if (hBitmap != IntPtr.Zero)
            {
                IntPtr hOld = (IntPtr)SelectObject(hMemDC, hBitmap);
                BitBlt(hMemDC, 0, 0, size.cx, size.cy, hDC, 0, 0, SRCCOPY);
                SelectObject(hMemDC, hOld);
                DeleteDC(hMemDC);
                ReleaseDC(GetDesktopWindow(), hDC);
                Bitmap bmp = System.Drawing.Image.FromHbitmap(hBitmap);
                DeleteObject(hBitmap);
                return bmp;
            }
            else
            {
                return null;
            }
        }
    }
    public class BSNuvemRevisao:NBindingSource1
    {
        public NBindingSource1 bsVistaAssociada;
        public BSNuvemRevisao(object iacesso):base(iacesso)
        {

        }
        protected override void OnPositionChanged(EventArgs e)
        {

            object o = this.Current.GetType().GetProperty(nameof(NUVEM_REVISAO.NUVEM_REVISAO_ID)).GetValue(this.Current);

            if (o != null)
            {
                int id;
                if (int.TryParse(o.ToString(), out id))
                    bsVistaAssociada.DataSource =  (bsVistaAssociada.Acesso as ACESSO_VISTA_ASSOCIADA).Selecionar(new VISTA_ASSOCIADA { NUVEM_REVISAO_ID = id });
            }
               
            base.OnPositionChanged(e);
        }
    }
}