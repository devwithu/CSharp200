using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using Com.JungBo.Drawings;
namespace Progject055{
    public class CableCar:Shape{
        Shape[] shsf;
        public CableCar(float x, float y) 
            :this(x,y, Color.SkyBlue){ }
        public CableCar(float x, float y, Color color)
            : base(x, y, 1f,1f,color){
        shsf = new Shape[5];  //�θ��� Ÿ�� �迭
//--������縸���
shsf[0] = new Rectangler(x, y, 40, 20, color);//�������
shsf[1] = new Circle(x + 8, y - 16, 10, 10, color);//�ڹ���
shsf[2] = new Circle(x + 24, y - 16, 10, 10, color);//�չ���
shsf[3] = new Shape(x + 24 + 2, y - 16 + 1, 6,6, color);//�չ�����
shsf[4] = new Shape(x + 8 + 2, y - 16 + 1,6,6, color);//�ڹ�����
//---
        }
        //������� �׸���
        public override void Draw(Graphics g){
            foreach (Shape bus in shsf){
                bus.Draw(g); 
            }
        }
        //���� �̵���Ű��
        public void Go(float mx, float my){
            foreach (Shape bus in shsf){
                bus.Move(mx, my);
            }
        }
    }
}
