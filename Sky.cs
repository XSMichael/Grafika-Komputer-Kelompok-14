using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digimon
{
    internal class Sky : MyObject
    {
        private int counter = 0;
        Assets cloud;
        Assets birds;

        public Sky()
        {

        }
        public Sky(Vector3 centerPosition, bool status = true)
        {
            this.setDefault();
            this._centerPosition = centerPosition;
            this.status = status;
        }
        public override void setDefault()
        {
            base.setDefault();
            radius_x = (float)400 / 400;
            radius_y = radius_x;
            radius_z = radius_x;
        }
        public override void load(string shaderVert, string shaderFrag, float Size_x, float Size_y)
        {
            base.load(shaderVert, shaderFrag, Size_x, Size_y);
            Assets temp_object;

            parentObj = new Assets(1);

            #region awan
            //Awan 1
            cloud = new Assets(1, new Vector3(255, 255, 255));
            cloud.createEllipsoid(3f, 6f, -0.3f, 0.5f, 0.3f, 0.2f);
            cloud.createEllipsoid(3.1f, 5.7f, -0.4f, 0.6f, 0.3f, 0.3f);
            cloud.createEllipsoid(2.6f, 6f, -0.5f, 0.8f, 0.4f, 0.4f);
            cloud.createEllipsoid(3.8f, 6.2f, -0.5f, 0.8f, 0.4f, 0.4f);
            cloud.createEllipsoid(3f, 6.3f, -0.2f, 0.6f, 0.5f, 0.3f);
            parentObj.addChild(cloud);

            //Awan 2
            temp_object = new Assets(1, new Vector3(255, 255, 255));
            temp_object.createEllipsoid(-2.5f, 4.8f, 3.3f, 0.7f, 0.3f, 0.2f);
            temp_object.createEllipsoid(-2.4f, 4.5f, 3.4f, 0.6f, 0.3f, 0.3f);
            temp_object.createEllipsoid(-3f, 4.8f, 3.5f, 0.8f, 0.4f, 0.4f);
            temp_object.createEllipsoid(-2f, 5f, 3.5f, 0.9f, 0.4f, 0.4f);
            temp_object.createEllipsoid(-2.4f, 5.1f, 3.2f, 0.7f, 0.5f, 0.3f);
            cloud.addChild(temp_object);

            //Awan 3
            temp_object = new Assets(1, new Vector3(255, 255, 255));
            temp_object.createEllipsoid(2.5f, 4.8f, 4.3f, 0.7f, 0.3f, 0.2f);
            temp_object.createEllipsoid(2.4f, 4.5f, 4.4f, 0.6f, 0.3f, 0.3f);
            temp_object.createEllipsoid(3f, 4.8f, 4.5f, 0.8f, 0.4f, 0.4f);
            temp_object.createEllipsoid(2f, 5f, 4.5f, 0.9f, 0.4f, 0.4f);
            temp_object.createEllipsoid(2.4f, 5.1f, 4.2f, 0.7f, 0.5f, 0.3f);
            cloud.addChild(temp_object);
            #endregion

            //Matahari
            temp_object = new Assets(1, new Vector3(255, 240, 0));
            temp_object.createEllipsoid(0, 5.5f, 0, 0.7f, 0.7f, 0.7f);
            parentObj.addChild(temp_object);

            #region burung
            birds = new Assets();
            //Burung 1

            Assets burung = new Assets(2, new Vector3(0, 0, 0));
            burung.setVertices(new List<Vector3>());
            burung.addVertices(0.0f, 0.04f, 0f);
            burung.addVertices(0.0f, 0.0f, 0f);
            burung.addVertices(0.06f, 0.0f, 0f);
            burung.addVertices(0.06f, 0.04f, 0f);
            List<Vector3> temp = burung.createCurveBezier();
            burung.setVertices(new List<Vector3>());
            burung.addVertices(0.06f, 0.04f, 0f);
            burung.addVertices(0.06f, 0.0f, 0f);
            burung.addVertices(0.12f, 0.0f, 0f);
            burung.addVertices(0.12f, 0.04f, 0f);
            temp.AddRange(burung.createCurveBezier());

            burung.setVertices(temp);
            burung.setCenter(0.06f, 0.05f, 0f);
            burung.Scaling(new Vector3(5.2f, 3.8f, 1F));
            burung.Translation(new Vector3(-0.06f, 5.5f, 1.2f));
            burung.rotate(burung.getCenter(), burung._euler[0], 180f);
            birds.addChild(burung);

            //Burung 2

            burung = new Assets(2, new Vector3(0, 0, 0));
            burung.setVertices(new List<Vector3>());
            burung.addVertices(0.0f, 0.04f, 0f);
            burung.addVertices(0.0f, 0.0f, 0f);
            burung.addVertices(0.06f, 0.0f, 0f);
            burung.addVertices(0.06f, 0.04f, 0f);
            temp = burung.createCurveBezier();
            burung.setVertices(new List<Vector3>());
            burung.addVertices(0.06f, 0.04f, 0f);
            burung.addVertices(0.06f, 0.0f, 0f);
            burung.addVertices(0.12f, 0.0f, 0f);
            burung.addVertices(0.12f, 0.04f, 0f);
            temp.AddRange(burung.createCurveBezier());

            burung.setVertices(temp);
            burung.setCenter(0.06f, 0.05f, 0f);
            burung.Scaling(new Vector3(5.2f, 3.8f, 1F));
            burung.Translation(new Vector3(4f, 5.3f, 0.82f));
            burung.rotate(burung.getCenter(), burung._euler[0], 180f);
            birds.addChild(burung);


            //Burung 3

            burung = new Assets(2, new Vector3(0, 0, 0));
            burung.setVertices(new List<Vector3>());
            burung.addVertices(0.0f, 0.04f, 0f);
            burung.addVertices(0.0f, 0.0f, 0f);
            burung.addVertices(0.06f, 0.0f, 0f);
            burung.addVertices(0.06f, 0.04f, 0f);
            temp = burung.createCurveBezier();
            burung.setVertices(new List<Vector3>());
            burung.addVertices(0.06f, 0.04f, 0f);
            burung.addVertices(0.06f, 0.0f, 0f);
            burung.addVertices(0.12f, 0.0f, 0f);
            burung.addVertices(0.12f, 0.04f, 0f);
            temp.AddRange(burung.createCurveBezier());

            burung.setVertices(temp);
            burung.setCenter(0.06f, 0.05f, 0f);
            burung.Scaling(new Vector3(5.2f, 3.8f, 1F));
            burung.Translation(new Vector3(-2.6f, 4.9f, 3.6f));
            burung.rotate(burung.getCenter(), burung._euler[0], 180f);
            birds.addChild(burung);

            Assets tmp = new Assets(2, new Vector3(0, 0, 0));
            tmp.setVertices(new List<Vector3>());
            tmp.addVertices(0.0f, 0.00f, 0f);
            tmp.addVertices(0.0f, 0.00f, 0f);
            tmp.addVertices(0.0f, 0.00f, 0f);

            parentObj.addChild(birds);
            #endregion

            parentObj.load(shaderVert, shaderFrag, Size_x, Size_y);
            parentObj.Scaling(new Vector3(0.25f, 0.25f, 0.25f));
        }

        public override void render(FrameEventArgs args, Matrix4 camera_view, Matrix4 camera_projection)
        {
            base.render(args, camera_view, camera_projection);
            parentObj.render(camera_view, camera_projection);
            idle();
        }
        public void idle()
        {
            if (statusIdle1)
            {
                counter += 1;
                if (counter <= 60)
                {
                    cloud.Translation(new Vector3(-0.01f, 0, 0));
                    birds.Translation(new Vector3(0, 0.0013f, 0));
                }
                else if (counter <= 121)
                {
                    cloud.Translation(new Vector3(0.01f, 0, 0));
                    birds.Translation(new Vector3(0, -0.0013f, 0));
                }
                else
                {
                    counter = 0;
                }
            }
        }

    }
}
