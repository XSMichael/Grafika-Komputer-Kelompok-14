using LearnOpenTK.Common;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digimon
{
    internal class Budmon :MyObject
    {
        Assets tail;
        Assets mata;


        private float finalEyeIdle = 0.0004f;
        private float eyeIdle;

        
        private int counter = 0;

        public Budmon()
        {
            setDefault();
        }

        public Budmon(Vector3 centerPosition, bool status = true)
        {
            setDefault();
            this._centerPosition = centerPosition;
            this.status = status;
        }

        public override void setDefault()
        {
            base.setDefault();
            radius_x = (float)160 / 400;
            radius_y = radius_x;
            radius_z = radius_x;
            eyeIdle = finalEyeIdle;
        }

        public override void load(string shaderVert, string shaderFrag, float Size_x, float Size_y)
        {
            base.load(shaderVert, shaderFrag, Size_x, Size_y);
            Assets temp_object;
            //isi assets

            parentObj = new Assets(1, new Vector3(255, 217, 122));
            parentObj.createEllipsoid(_centerPosition.X, _centerPosition.Y, _centerPosition.Z, radius_x, radius_y, radius_z-0.05f);

            #region spike
            Assets spike = new Assets(1);
            temp_object = new Assets(1, new Vector3(224, 168, 211));
            temp_object.createEllipticParaboloid(0, 0, -radius_z - 0.17f, radius_x * 2 / 3, radius_y * 2 / 3, radius_z * 7 / 16, radius_z * 18 / 16);
            temp_object.rotate(_centerPosition, temp_object._euler[0], 90);
            parentObj.addChild(temp_object);
            spike.addChild(temp_object);

            temp_object = new Assets(1, new Vector3(255, 255, 255));
            temp_object.createEllipticParaboloid(0, 0, -radius_z - 0.17f, radius_x * 2 / 3, radius_y * 2 / 3, 0, radius_z * 7 / 16);
            temp_object.rotate(_centerPosition, temp_object._euler[0], 90);
            parentObj.addChild(temp_object);
            spike.addChild(temp_object);

            temp_object = new Assets(1, new Vector3(255, 217, 122));
            temp_object.createEllipsoid(0, radius_y - 0.033F, 0, 0.15f, 0.05f, 0.15f);
            parentObj.addChild(temp_object);
            spike.addChild(temp_object);
            spike.rotate(_centerPosition, spike._euler[0], 10);


            spike = new Assets(1);

            temp_object = new Assets(1, new Vector3(224, 168, 211));
            temp_object.createEllipticParaboloid(0, 0, -radius_z - 0.13f, radius_x * 1.15f / 3, radius_y * 1.15f / 3, radius_z * 3f/8, radius_z*1f );
            temp_object.rotate(_centerPosition, temp_object._euler[0], 90);
            spike.addChild(temp_object);

            temp_object = new Assets(1, new Vector3(255, 255, 255));
            temp_object.createEllipticParaboloid(0, 0, -radius_z - 0.13f, radius_x * 1.15f / 3, radius_y * 1.15f / 3, 0, radius_z * 3f / 8);
            temp_object.rotate(_centerPosition, temp_object._euler[0], 90);
            spike.addChild(temp_object);

            temp_object = new Assets(1, new Vector3(255, 217, 122));
            temp_object.createEllipsoid(0, radius_y - 0.02F, 0, 0.068f, 0.03f, 0.068f);
            spike.addChild(temp_object);

            temp_object = new Assets(spike);
            temp_object.rotate(_centerPosition, spike._euler[2], -38);
            temp_object.rotate(_centerPosition, spike._euler[0], 30);
            parentObj.addChild(temp_object);

            temp_object = new Assets(spike);
            temp_object.rotate(_centerPosition, spike._euler[2], -33);
            temp_object.rotate(_centerPosition, spike._euler[0], -30);
            parentObj.addChild(temp_object);

            temp_object = new Assets(spike);
            temp_object.rotate(_centerPosition, spike._euler[2], 33);
            temp_object.rotate(_centerPosition, spike._euler[0], -30);
            parentObj.addChild(temp_object);


            spike.rotate(_centerPosition, spike._euler[2], 38);
            spike.rotate(_centerPosition, spike._euler[0], 30);
            parentObj.addChild(spike);

            //kaki
            spike = new Assets();
            temp_object = new Assets(1, new Vector3(224, 168, 211));
            temp_object.createEllipticParaboloid(0, 0, -radius_z - 0.08f, radius_x * 1 / 3, radius_y * 1 / 3, radius_z * 1.4f);
            temp_object.Scaling(new Vector3(0.9f,0.9f,1));
            temp_object.rotate(_centerPosition, temp_object._euler[0], -90);
            spike.addChild(temp_object);

            temp_object = new Assets(spike);
            temp_object.rotate(_centerPosition, spike._euler[2], -27);
            temp_object.rotate(_centerPosition, spike._euler[0], 20);
            parentObj.addChild(temp_object);

            temp_object = new Assets(spike);
            temp_object.rotate(_centerPosition, spike._euler[2], -27);
            temp_object.rotate(_centerPosition, spike._euler[0], -20);
            parentObj.addChild(temp_object);

            temp_object = new Assets(spike);
            temp_object.rotate(_centerPosition, spike._euler[2], 27);
            temp_object.rotate(_centerPosition, spike._euler[0], -20);
            parentObj.addChild(temp_object);


            spike.rotate(_centerPosition, spike._euler[2], 27);
            spike.rotate(_centerPosition, spike._euler[0], 20);
            parentObj.addChild(spike);

            #endregion

            #region ekor
            //ekor
            tail = new Assets();
            temp_object = new Assets(1, new Vector3(219, 197, 83));
            temp_object.createEllipticParaboloid(0, -0.45f, -0.98f, 0.24f, 0.1f, 0.62f);
            temp_object.rotate(temp_object.getCenter(), tail._euler[0], -90f);        
            //parentObj.addChild(temp_object);
            tail.addChild(temp_object);
            temp_object = new Assets(1, new Vector3(219, 197, 83));
            temp_object.createEllipticParaboloid(0, 0.317f, -0.98f, 0.24f, 0.1f, 0.62f);
            temp_object.rotate(temp_object.getCenter(), tail._euler[0], -270f);
            //parentObj.addChild(temp_object);
            tail.addChild(temp_object);
            tail.setCenter(temp_object.getCenter().X, temp_object.getCenter().Y, temp_object.getCenter().Z);
            tail.rotate(tail.getCenter(), tail._euler[0], -58f);
            tail.Translation(new Vector3(0, -0.22f, 0.115f));
            parentObj.addChild(tail);   
            #endregion

            #region mulut
            //mulut
            Assets mulut = new Assets();
            temp_object = new Assets(1, new Vector3(145, 7, 7));
            temp_object.createCylinder2(0, (-radius_y * 1 / 2)+0.1f, radius_z-0.058f , radius_x / 7, (radius_y / 5)-0.01f, 0.01f);
            temp_object.rotate(temp_object.getCenter(), temp_object._euler[2], 180f);
            mulut.addChild(temp_object);
            temp_object = new Assets(2, new Vector3(0, 0, 0) );
            temp_object.createCylinder2(0, (-radius_y * 1 / 2) + 0.1f, radius_z - 0.058f, radius_x / 7, (radius_y / 5) - 0.01f, 0.01f);
            temp_object.rotate(temp_object.getCenter(), temp_object._euler[2], 180f);        
            mulut.addChild(temp_object);

            temp_object = new Assets(1, new Vector3(242, 0, 0));
            temp_object.createEllipsoid(-0.008f, (-radius_y * 1 / 2) + 0.049f, radius_z - 0.054f, 0.0225f, 0.017f, 0.01f);
            temp_object.rotate(temp_object.getCenter(), temp_object._euler[2], -27f);
            mulut.addChild(temp_object);
            temp_object = new Assets(1, new Vector3(242, 0, 0));
            temp_object.createEllipsoid(0.008f, (-radius_y * 1 / 2) + 0.049f, radius_z - 0.054f, 0.0225f, 0.017f, 0.01f);
            temp_object.rotate(temp_object.getCenter(), temp_object._euler[2], 27f);
            mulut.addChild(temp_object);

            temp_object = new Assets(1, new Vector3(255, 255, 255));
            temp_object.createEllipticParaboloid(0.01f, (-radius_y * 1 / 2) + 0.1f, radius_z - 0.058f, 0.07f, 0.05f, 0.11f);
            temp_object.Scaling(new Vector3(0.87f, 0.87f, 1));
            temp_object.rotate(temp_object.getCenter(), temp_object._euler[0], -90);
            temp_object.Translation(new Vector3(0.024f, -0.0265f, 0.0049f));
            mulut.addChild(temp_object);

            mulut.rotate(new Vector3(0, (-radius_y * 1 / 2) + 0.1f, radius_z - 0.058f), temp_object._euler[0], 15f);
            parentObj.addChild(mulut);
            #endregion

            #region mata
            mata = new Assets();
            //mata kanan           

            Assets mataKanan = new Assets(2, new Vector3(0, 0, 0));
            mataKanan.setVertices(new List<Vector3>());
            mataKanan.addVertices(0.0f, 0f, 0);
            mataKanan.addVertices(1f, 1f, -0.03f);
            mataKanan.addVertices(1.5f, 0.05f, 0);
            mataKanan.setVertices(mataKanan.createCurveBezier());
            mataKanan.rotate(mataKanan.getCenter(), mataKanan._euler[0], -8);
            mataKanan.rotate(mataKanan.getCenter(), mataKanan._euler[1], 19f);
            mataKanan.Translation(new Vector3(0.8f, 0, 0));
            mata.addChild(mataKanan);

            //mata kiri
            Assets mataKiri = new Assets(2, new Vector3(0, 0, 0));
            mataKiri.addVertices(-0.0f, 0.0f, 0);
            mataKiri.addVertices(-1f, 1f, -0.03f);
            mataKiri.addVertices(-1.5f, 0.05f, 0);
            mataKiri.setVertices(mataKiri.createCurveBezier());
            mataKiri.rotate(mataKiri.getCenter(), mataKiri._euler[0], -8f);
            mataKiri.rotate(mataKiri.getCenter(), mataKiri._euler[1], -19f);
            mataKiri.Translation(new Vector3(-0.8f, 0, 0));
            mata.addChild(mataKiri);
            mata.Scaling(new Vector3(0.1f, 0.1f, 0.1f));
            mata.Translation(new Vector3(0, 0.1f, 0.335f));

            Assets temp = new Assets(2, new Vector3(0, 0, 0));
            temp.setVertices(new List<Vector3>());
            temp.addVertices(0.0f, 0.00f, 0f);
            temp.addVertices(0.0f, 0.00f, 0f);
            temp.addVertices(0.0f, 0.00f, 0f);
            
            parentObj.addChild(mata);
            #endregion

            #region blush
            //blush
            temp_object = new Assets(2, new Vector3(252, 197, 248));
            temp_object.createEllipsoid(radius_x / 2, 0, radius_z-0.085f, radius_x/8, radius_y /24, 0.01f);
            temp_object.Translation(new Vector3(0,0, -0.012f));
            temp_object.rotate(temp_object.getCenter(), temp_object._euler[1], 25);
            parentObj.addChild(temp_object);

            temp_object = new Assets(2, new Vector3(252, 197, 248));
            temp_object.createEllipsoid(-radius_x / 2, 0, radius_z -0.085f, radius_x / 8, radius_y / 24, 0.01f);
            temp_object.Translation(new Vector3(0, 0, -0.012f));
            temp_object.rotate(temp_object.getCenter(), temp_object._euler[1], -25);
            parentObj.addChild(temp_object);

            temp_object = new Assets(2, new Vector3(252, 197, 248));
            temp_object.createEllipsoid(-radius_x / 2, 0, radius_z - 0.085f, radius_x / 8, radius_y / 24, 0.01f);
            temp_object.Translation(new Vector3(0, 0, -0.012f));
            temp_object.rotate(temp_object.getCenter(), temp_object._euler[1], -25);
            parentObj.addChild(temp_object);
            #endregion

            parentObj.Scaling(new Vector3(0.375f, 0.375f, 0.375f));
            Translation(-1.0f, -0.085f, 0.55f);
            parentObj.load(shaderVert, shaderFrag, Size_x, Size_y);
            walkSpeed = walkSpeed * 165 / 100;
            border = border * 0.9f;
        }


        public override void render(FrameEventArgs args, Matrix4 camera_view, Matrix4 camera_projection)
        {
            base.render(args, camera_view, camera_projection);

            parentObj.render(camera_view, camera_projection);
            idle();
            idle2();
        }

      
        public void idle()
        {
            if (statusIdle1)
            {
                if (counter <= 60)
                {
                    eyeIdle = eyeIdle * 0.9975f;
                    Scale(1 / 0.9965f, 0.9975f, 1 / 0.9965f);
                    
                    mata.Translation(new Vector3(0, eyeIdle, 0));
                    if(counter <= 30)
                    {
                        Translation(0, (radius_y * 4 / 240) * eyeIdle / finalEyeIdle, 0);
                    }
                    else
                    {
                        Translation(0,(-radius_y * 4 / 240) * eyeIdle / finalEyeIdle, 0);
                    }
                }
                else if (counter <= 120)
                {
                    eyeIdle = eyeIdle *1/ 0.9975f;
                    Scale(0.9965f, 1 / 0.9975f, 0.9965f);
                    mata.Translation(new Vector3(0, -eyeIdle, 0)); 
                }
                else
                {
                    counter = 0;
                    eyeIdle = finalEyeIdle;    
                }
                counter += 1;
            }
        }

        public override void Scale(float scaleX, float scaleY, float scaleZ)
        {
            base.Scale(scaleX, scaleY, scaleZ);
            finalEyeIdle *= scaleY;
            eyeIdle *= scaleY;
        }

        public override void resetScale()
        {
            base.resetScale();
            finalEyeIdle *= (1/current_scale.Y);
            eyeIdle *= (1 / current_scale.Y);
        }
    }
}
