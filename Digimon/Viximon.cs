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
    internal class Viximon : MyObject
    {
        Assets tail;
        Assets ear1;
        Assets ear2;
        private Assets mulut;
        private int counter = 0;

        public Viximon()
        {
            setDefault();
        }

        public Viximon(Vector3 centerPosition, bool status = true)
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
        }

        public override void load(string shaderVert, string shaderFrag, float Size_x, float Size_y)
        {
            base.load(shaderVert, shaderFrag, Size_x, Size_y);
            Assets temp_object;
            //isi assets

            parentObj = new Assets(1, new Vector3(255, 230, 255));
            temp_object = new Assets(1, new Vector3(255, 230, 0));
            temp_object.createEllipsoid(0.0f, 0.0f, 0.0f, 0.4f, 0.4f, 0.5f);
            parentObj.addChild(temp_object);

            #region ekor
            //ekor
            tail = new Assets(1, new Vector3(255, 230, 0));
            tail.createEllipsoid(0.0f, 0.2f, -0.5f, 0.5f, 0.1f, 0.1f);
            tail.rotate(tail.getCenter(), tail._euler[2], 90f);
            tail.rotate(tail.getCenter(), tail._euler[1], 60f);
            tail.setCenter(0, -radius_y * 38 / 40, -radius_z);
            parentObj.addChild(tail);

            temp_object = new Assets(1, new Vector3(255, 255, 255));
            temp_object.createEllipticParaboloid(0.0f, 0.52f, -1.05f, 0.12f, 0.12f, 0.6f);
            temp_object.rotate(temp_object.getCenter(), temp_object._euler[0], 30f);

            tail.addChild(temp_object);
            #endregion


            #region mata
            //Mata putih

            temp_object = new Assets(1, new Vector3(255, 255, 255));
            temp_object.createCylinder2(-0.15f, -0.05f, 0.33f, 0.1f, 0.2f, 0.3f);
            temp_object.rotate(temp_object.getCenter(), temp_object._euler[1], 180);
            parentObj.addChild(temp_object);

            temp_object = new Assets(1, new Vector3(255, 255, 255));
            temp_object.createCylinder2(0.15f, -0.05f, 0.33f, 0.1f, 0.2f, 0.3f);
            temp_object.rotate(temp_object.getCenter(), temp_object._euler[1], 180);
            parentObj.addChild(temp_object);

            //pupils
            temp_object = new Assets(1, new Vector3(51, 153, 255));
            temp_object.createCylinder2(-0.13f, -0.05f, 0.48f, 0.07f, 0.15f, 0.05f);
            temp_object.rotate(temp_object.getCenter(), temp_object._euler[1], 180);
            parentObj.addChild(temp_object);

            temp_object = new Assets(1, new Vector3(51, 153, 255));
            temp_object.createCylinder2(0.13f, -0.05f, 0.48f, 0.07f, 0.15f, 0.05f);
            temp_object.rotate(temp_object.getCenter(), temp_object._euler[1], 180);
            parentObj.addChild(temp_object);

            //alis kiri
            Assets alisKiri = new Assets(2, new Vector3(0, 0, 0));
            alisKiri.setVertices(new List<Vector3>());
            alisKiri.addVertices(0.0f, 0.02f, 1.0f);
            alisKiri.addVertices(0.05f, 0.05f, 1.0f);
            alisKiri.addVertices(0.10f, 0.0f, 1.0f);
            alisKiri.setVertices(alisKiri.createCurveBezier());
            alisKiri.Translation(new Vector3(0.1f, 0.22f, -0.57f));
            parentObj.addChild(alisKiri);

            //alis kanan
            Assets alisKanan = new Assets(2, new Vector3(0, 0, 0));
            alisKanan.setVertices(new List<Vector3>());
            alisKanan.addVertices(0.0f, 0.02f, 1.0f);
            alisKanan.addVertices(-0.05f, 0.05f, 1.0f);
            alisKanan.addVertices(-0.10f, 0.0f, 1.0f);
            alisKanan.setVertices(alisKanan.createCurveBezier());
            alisKanan.Translation(new Vector3(-0.1f, 0.22f, -0.57f));
            parentObj.addChild(alisKanan);

            //Eye details
            temp_object = new Assets(1, new Vector3(0, 0, 0));
            temp_object.createEllipsoid(0.13f, 0.027f, 0.5f, 0.04f, 0.05f, 0.02f);
            parentObj.addChild(temp_object);

            temp_object = new Assets(1, new Vector3(255, 255, 255));
            temp_object.createEllipsoid(0.16f, 0.08f, 0.5f, 0.025f, 0.025f, 0.01f);
            parentObj.addChild(temp_object);

            temp_object = new Assets(1, new Vector3(255, 255, 255));
            temp_object.createEllipsoid(0.09f, -0.01f, 0.52f, 0.015f, 0.015f, 0.01f);
            parentObj.addChild(temp_object);

            temp_object = new Assets(1, new Vector3(0, 0, 0));
            temp_object.createEllipsoid(-0.13f, 0.027f, 0.5f, 0.04f, 0.05f, 0.02f);
            parentObj.addChild(temp_object);

            temp_object = new Assets(1, new Vector3(255, 255, 255));
            temp_object.createEllipsoid(-0.16f, 0.08f, 0.5f, 0.025f, 0.025f, 0.01f);
            parentObj.addChild(temp_object);

            temp_object = new Assets(1, new Vector3(255, 255, 255));
            temp_object.createEllipsoid(-0.09f, -0.01f, 0.52f, 0.015f, 0.015f, 0.01f);
            parentObj.addChild(temp_object);
            #endregion

            #region telinga
            //Telinga 
            ear1 = new Assets(1, new Vector3(255, 230, 0));
            ear1.createEllipticParaboloid(-0.3f, 0.65f, 0.2f, 0.5f / 4, 0.2f / 4, 0.5f * 4 / 3);
            parentObj.addChild(ear1);

            temp_object = new Assets(1, new Vector3(255, 255, 255));
            temp_object.createEllipticParaboloid(-0.3f, 0.65f, 0.2f, 0.55f / 4, 0.25f / 4, 0.4f * 4 / 3);

            ear1.addChild(temp_object);

            ear1.rotate(temp_object.getCenter(), temp_object._euler[0], 90);
            ear1.rotate(temp_object.getCenter(), temp_object._euler[1], 15);


            ear2 = new Assets(1, new Vector3(255, 230, 0));
            ear2.createEllipticParaboloid(0.3f, 0.65f, 0.2f, 0.5f / 4, 0.2f / 4, 0.5f * 4 / 3);
            parentObj.addChild(ear2);

            temp_object = new Assets(1, new Vector3(255, 255, 255));
            temp_object.createEllipticParaboloid(0.3f, 0.65f, 0.2f, 0.55f / 4, 0.25f / 4, 0.4f * 4 / 3);

            ear2.addChild(temp_object);

            ear2.rotate(temp_object.getCenter(), temp_object._euler[0], 90);
            ear2.rotate(temp_object.getCenter(), temp_object._euler[1], -15);
            #endregion

            #region kaki
            //kaki
            temp_object = new Assets(1, new Vector3(255, 230, 0));
            temp_object.createEllipsoid(-0.24f, -0.30f, 0.25f, 0.07f, 0.13f, 0.07f);
            parentObj.addChild(temp_object);
            temp_object.rotate(temp_object.getCenter(), temp_object._euler[2], -20);

            temp_object = new Assets(1, new Vector3(255, 230, 0));
            temp_object.createEllipsoid(-0.24f, -0.30f, -0.25f, 0.07f, 0.13f, 0.07f);
            parentObj.addChild(temp_object);
            temp_object.rotate(temp_object.getCenter(), temp_object._euler[2], -20);

            temp_object = new Assets(1, new Vector3(255, 230, 0));
            temp_object.createEllipsoid(0.24f, -0.30f, 0.25f, 0.07f, 0.13f, 0.07f);
            parentObj.addChild(temp_object);
            temp_object.rotate(temp_object.getCenter(), temp_object._euler[2], 20);

            temp_object = new Assets(1, new Vector3(255, 230, 0));
            temp_object.createEllipsoid(0.24f, -0.30f, -0.25f, 0.07f, 0.13f, 0.07f);
            parentObj.addChild(temp_object);
            temp_object.rotate(temp_object.getCenter(), temp_object._euler[2], 20);

            #endregion

            #region uwu mouth
            //UWU mouth
            mulut = new Assets(2, new Vector3(0, 0, 0));
            mulut.setVertices(new List<Vector3>());
            mulut.addVertices(0.0f, 0.03f, 1.0f);
            mulut.addVertices(0.03f, 0.0f, 1.0f);
            mulut.addVertices(0.06f, 0.03f, 1.0f);
            List<Vector3> mulutKiri = new List<Vector3>();
            mulutKiri = mulut.createCurveBezier();

            mulut.setVertices(new List<Vector3>());
            mulut.addVertices(0.06f, 0.03f, 1.0f);
            mulut.addVertices(0.09f, 0.0f, 1.0f);
            mulut.addVertices(0.12f, 0.03f, 1.0f);
            List<Vector3> mulutKanan = new List<Vector3>();
            mulutKanan = mulut.createCurveBezier();
            mulutKiri.AddRange(mulutKanan);

            mulut.setVertices(mulutKiri);
            mulut.Translation(new Vector3(-0.06f, -0.15f, -0.51f));
            parentObj.addChild(mulut);
            #endregion

            Assets temp = new Assets(2, new Vector3(0, 0, 0));
            temp.setVertices(new List<Vector3>());
            temp.addVertices(0.0f, 0.00f, 0f);
            temp.addVertices(0.0f, 0.00f, 0f);
            temp.addVertices(0.0f, 0.00f, 0f);
            parentObj.addChild(temp);

            Translation(-0.0f, -0.17f, 0.0f);
            parentObj.Scaling(new Vector3(0.4f, 0.4f, 0.4f));
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
                Vector3 body = parentObj.getCenter();
                counter += 1;
                if (counter <= 60)
                {
                    Scale(0.9965f, 1 / 0.9965f, 0.9965f);
                    tail.rotate(tempCenter, tail._euler[1], 0.75f);
                    ear1.rotate(body, ear1._euler[1], 0.3f);
                    ear2.rotate(body, ear1._euler[1], -0.3f);
                }
                else if (counter <= 121)
                {
                    Scale(1 / 0.9965f, 0.9965f, 1 / 0.9965f);
                    tail.rotate(tempCenter, tail._euler[1], -0.75f);
                    ear1.rotate(body, ear1._euler[1], -0.3f);
                    ear2.rotate(body, ear1._euler[1], 0.3f);
                }
                else
                {
                    counter = 0;
                }
            }
        }

    }
}
