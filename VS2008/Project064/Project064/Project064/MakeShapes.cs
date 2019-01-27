using System;
using System.Drawing;
namespace Com.JungBo.Drawings{
    public class MakeShapes{
        byte[,] colors =   {{255, 0, 0}, {0, 255, 0}, {0, 0, 255},
							{255, 255, 0}, {255, 0, 255}, {0, 255, 255},
							{0, 128, 255}, {0, 255, 128}, {255, 0, 128}, 
							{128, 0, 255}, {255, 128, 0}, {128, 255, 0}};
        
        ShapeList shlist = new ShapeList();

        Random r;
        static int SEED = 37;
        int maxWidth;
        int maxHeight;
        public MakeShapes(int maxWidth, int maxHeight){
            r = new Random(SEED++ + DateTime.Now.Millisecond);
            this.maxWidth = maxWidth;
            this.maxHeight = maxHeight;
        }
        //shlist 겟 프로퍼티
        public ShapeList ShapeList{
            get{
                return shlist;
            }
        }
        public void Make(bool isNew){
            shlist.IsNew = isNew;
            shlist.Clear(); //청소
            for (int i = 0; i < 30; i++){
                Shape sh = new Shape(r.Next(maxWidth), r.Next(maxHeight),
                    r.Next(1, 50), r.Next(1, 50),
                    FromRGB(r.Next(0, colors.GetLength(0))));
                DoubleCricle dsh = new DoubleCricle(r.Next(maxWidth),
                    r.Next(maxHeight),r.Next(1, 50), r.Next(1, 50),
                    FromRGB(r.Next(0, colors.GetLength(0))));
                Circle c1 = new Circle(r.Next(maxWidth), r.Next(maxHeight),
                    r.Next(1, 50), r.Next(1, 50),
                    FromRGB(r.Next(0, colors.GetLength(0))));
                Rectangler rtg = new Rectangler(r.Next(maxWidth), 
                    r.Next(maxHeight), r.Next(1, 50), r.Next(1, 50),
                    FromRGB(r.Next(0, colors.GetLength(0))));
                shlist.Add(sh);  
                shlist.Add(dsh);
                shlist.Add(c1);
                shlist.Add(rtg);
            }
        }
        private Color FromRGB(int m){
            Color col = Color.FromArgb(colors[m, 0],
                colors[m, 1], colors[m, 2]);
            return col;
        }
    }
}
