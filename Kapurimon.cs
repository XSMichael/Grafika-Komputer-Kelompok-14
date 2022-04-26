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
    internal class Kapurimon : MyObject
    {

        Assets tail;
        Assets tail2;
        Assets leftEar;
        Assets rightEar;

        private int counter = 0;

        public Kapurimon()
        {
            this.setDefault();
        }

        public Kapurimon(Vector3 centerPosition, bool status = true)
        {
            this.setDefault();
            this._centerPosition = centerPosition;
            this.status = status;
        }

        public override void setDefault()
        {
            base.setDefault();
            radius_x = (float)160 / 400;
            radius_y = radius_x;
            radius_z = radius_x;
        }

        public override void load(string shaderVert, string shaderFrag, float Size_x, float Size_y)
        {
            base.load(shaderVert, shaderFrag, Size_x, Size_y);
            Assets temp_object;
            //isi assets

            parentObj = new Assets(1, new Vector3(117, 112, 219));

            parentObj.createEllipsoid(0, 0, 0, 0.85f, 0.8f, 0.85f);

            temp_object = new Assets(1, new Vector3(200, 200, 200));
            temp_object.createEllipsoid(0, -0.4f, 0.001f, 0.65f, 0.4f, 0.65f);
            parentObj.addChild(temp_object);

            #region ear
            //RIGHT EAR
            rightEar = new Assets(1, new Vector3(220, 220, 220));
            rightEar.createEllipticParaboloid(-0.83f, 1f, 0.25f, 0.4f, 0.4f, 0.75f);
            rightEar.rotate(rightEar.getCenter(), rightEar._euler[0], 90);
            rightEar.rotate(rightEar.getCenter(), rightEar._euler[1], 37);
            parentObj.addChild(rightEar);

            //LEFT EAR
            leftEar = new Assets(1, new Vector3(220, 220, 220));
            leftEar.createEllipticParaboloid(0.83f, 1f, 0.25f, 0.4f, 0.4f, 0.75f);
            leftEar.rotate(leftEar.getCenter(), leftEar._euler[0], 90);
            leftEar.rotate(leftEar.getCenter(), leftEar._euler[1], -37);
            parentObj.addChild(leftEar);
            #endregion

            #region eye
            //LEFT EYE
            temp_object = new Assets(1, new Vector3(250, 250, 250));
            temp_object.createCylinder(radius_x - 0.05f, radius_y / 4, 0.8f, radius_x / 2.25f, radius_y / 2.2f, 0.05f);
            temp_object.rotate(temp_object.getCenter(), temp_object._euler[1], 15);
            parentObj.addChild(temp_object);

            //black line
            temp_object = new Assets(2, new Vector3(0, 0, 0));
            temp_object.createCircle(radius_x - 0.05f, radius_y / 4, 0.8f, radius_x / 2.25f, radius_y / 2.2f);
            temp_object.rotate(temp_object.getCenter(), temp_object._euler[1], 15);
            parentObj.addChild(temp_object);

            //orange
            temp_object = new Assets(1, new Vector3(255, 127, 0));
            temp_object.createCircle(radius_x - 0.058f, (radius_y / 4) + 0.02f, 0.83f, radius_x / 2.75f, radius_y / 2.55f);
            temp_object.rotate(temp_object.getCenter(), temp_object._euler[1], 15);
            parentObj.addChild(temp_object);

            //black
            temp_object = new Assets(1, new Vector3(0, 0, 0));
            temp_object.createCircle(radius_x - 0.05f, (radius_y / 4) + 0.03f, 0.84f, radius_x / 6f, radius_y / 6f);
            temp_object.rotate(temp_object.getCenter(), temp_object._euler[1], 15);
            parentObj.addChild(temp_object);

            //Small whiteglow
            temp_object = new Assets(1, new Vector3(250, 250, 250));
            temp_object.createCircle(radius_x - 0.11f, (radius_y / 4) + 0.1f, 0.86f, radius_x / 7.5f, radius_y / 7.5f);
            temp_object.rotate(temp_object.getCenter(), temp_object._euler[1], 15);
            parentObj.addChild(temp_object);

            //RIGHT EYE
            temp_object = new Assets(1, new Vector3(250, 250, 250));
            temp_object.createCylinder(-radius_x + 0.05f, radius_y / 4, 0.8f, radius_x / 2.25f, radius_y / 2.2f, 0.05f);
            temp_object.rotate(temp_object.getCenter(), temp_object._euler[1], -15);
            parentObj.addChild(temp_object);

            //black line
            temp_object = new Assets(2, new Vector3(0, 0, 0));
            temp_object.createCircle(-radius_x + 0.05f, radius_y / 4, 0.8f, radius_x / 2.25f, radius_y / 2.2f);
            temp_object.rotate(temp_object.getCenter(), temp_object._euler[1], -15);
            parentObj.addChild(temp_object);

            //orange
            temp_object = new Assets(1, new Vector3(255, 127, 0));
            temp_object.createCircle(-radius_x + 0.058f, (radius_y / 4) + 0.02f, 0.83f, radius_x / 2.75f, radius_y / 2.55f);
            temp_object.rotate(temp_object.getCenter(), temp_object._euler[1], -15);
            parentObj.addChild(temp_object);

            //black
            temp_object = new Assets(1, new Vector3(0, 0, 0));
            temp_object.createCircle(-radius_x + 0.05f, (radius_y / 4) + 0.03f, 0.84f, radius_x / 6, radius_y / 6);
            temp_object.rotate(temp_object.getCenter(), temp_object._euler[1], -15);
            parentObj.addChild(temp_object);

            //Small whiteglow
            temp_object = new Assets(1, new Vector3(250, 250, 250));
            temp_object.createCircle(-radius_x + 0.01f, (radius_y / 4) + 0.1f, 0.86f, radius_x / 7.5f, radius_y / 7.5f);
            temp_object.rotate(temp_object.getCenter(), temp_object._euler[1], -15);
            parentObj.addChild(temp_object);
            #endregion

            #region nose
            //nose
            temp_object = new Assets(1, new Vector3(0, 0, 0));
            temp_object.createEllipsoid(0, -0.05f, 0.85f, 0.02f, 0.02f, 0.02f);
            parentObj.addChild(temp_object);
            #endregion

            #region mouth
            //mouth
            Assets mouth = new Assets(2, new Vector3(0, 0, 0));
            mouth.setVertices(new List<Vector3>());
            mouth.addVertices(0.0f, 0.03f, 0f);
            mouth.addVertices(0.03f, 0.0f, 0f);
            mouth.addVertices(0.06f, 0.03f, 0f);
            List<Vector3>  temp = mouth.createCurveBezier();
            mouth.setVertices(new List<Vector3>());
            mouth.addVertices(0.06f, 0.03f, 0f);
            mouth.addVertices(0.09f, 0.0f, 0f);
            mouth.addVertices(0.12f, 0.03f, 0f);
            temp.AddRange(mouth.createCurveBezier());

            mouth.setVertices(temp);
            mouth.Scaling(new Vector3(2.2f, 2.4f, 1.2f));
            mouth.Translation(new Vector3(-0.117f, -0.28f, 0.82f));
            parentObj.addChild(mouth);
            #endregion

            #region tail
            //tail
            tail = new Assets(1, new Vector3(200, 200, 200));
            tail.createEllipsoid(0, -0.2f, -0.9f, 0.3f, 0.2f, 1f);
            tail.rotate(tail.getCenter(), tail._euler[0], 20f);
            tail.createEllipticParaboloid(0, 0f, -0.9f, 0.4f, 0.5f, 0.3f);
            parentObj.addChild(tail);

            //tail2
            tail2 = new Assets(1, new Vector3(117, 112, 219));
            tail2.createEllipticParaboloid(0, 0.3f, -2.2f, 0.2f, 0.2f, 0.7f);
            tail2.rotate(tail2.getCenter(), tail2._euler[0], 20f);
            parentObj.addChild(tail2);
            #endregion
            
            
            parentObj.Translation(new Vector3(3.5f, -0.5f, 1.5f));
            _centerPosition = new Vector3(0.73f, -0.5f, 0.21f);
            parentObj.Scaling(new Vector3(0.2f, 0.2f, 0.2f));
            Translation(0, 0, 0.9f);
            parentObj.load(shaderVert, shaderFrag, Size_x, Size_y);
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
                Vector3 tempCenter = tail.getCenter();
                Vector3 tempCenter2 = leftEar.getCenter();
                Vector3 tempCenter3 = rightEar.getCenter();
                counter += 1;
                if (counter <= 60)
                {
                    Scale(1 / 0.998f, 0.998f, 1 / 0.998f);
                    tail.rotate(tempCenter, tail._euler[1], 0.5f);
                    tail2.rotate(tempCenter, tail2._euler[1], 0.5f);
                    leftEar.rotate(tempCenter2, leftEar._euler[1], 0.05f);
                    rightEar.rotate(tempCenter3, rightEar._euler[1], 0.05f);

                }
                else if (counter <= 120)
                {
                    Scale(0.998f, 1 / 0.998f, 0.998f);
                    tail.rotate(tempCenter, tail._euler[1], -0.5f);
                    tail2.rotate(tempCenter, tail2._euler[1], -0.5f);
                    leftEar.rotate(tempCenter2, leftEar._euler[1], -0.05f);
                    rightEar.rotate(tempCenter3, rightEar._euler[1], -0.05f);
                }
                else if (counter > 120)
                {
                    counter = 0;

                }
            }
        }

    }
}
