using System;
using System.Collections.Generic;
using System.Drawing;
namespace Com.JungBo.Drawings{

    public class ShapeList{
        List<Shape> list = new List<Shape>(10);

        bool isNew = false;//new 오버라이드인가?
        public ShapeList(){
        }
        public void Clear() {
            list.Clear();
        }
        public void Add(Shape sh) {
            list.Add(sh);
        }
        public bool IsNew{
            get { return isNew; }
            set { isNew = value; }
        }
        public void PrintShape(Graphics g) {
            foreach (Shape shs in list){
                shs.Draw(g);
            }
        }//
    }
}
