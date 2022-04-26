using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digimon
{
    internal class House : MyObject
    {
        public House()
        {

        }
        public House(Vector3 centerPosition, bool status = true)
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
            //isi assets

            parentObj = new Assets(1);
            temp_object = new Assets(0, new Vector3(209, 126, 25) );
            temp_object.createBoxVertices(0, 0, 0, radius_x, radius_y, radius_z);
            parentObj.addChild(temp_object);

            #region door
            //door
            temp_object = new Assets(0, new Vector3(105, 57, 0) );
            temp_object.createBoxVertices(0, -radius_y/4, (radius_z/2)+0.005f, radius_x/4, radius_y/2, 0.01f);
            parentObj.addChild(temp_object);

            //lockdoor
            temp_object = new Assets(1, new Vector3(227, 182, 0));
            temp_object.createCylinder(-radius_x*1/16,-radius_y / 4, (radius_z / 2) + 0.005f, 0.01f, 0.01f, 0.01f);
            parentObj.addChild(temp_object);
            temp_object = new Assets(1, new Vector3(227, 182, 0));
            temp_object.createEllipsoid(-radius_x * 1 / 16, -radius_y / 4, (radius_z / 2) + 0.015f, 0.015f, 0.015f, 0.005f);
            parentObj.addChild(temp_object);
            #endregion

            #region atap
            //atap
            Assets atap = new Assets();
            temp_object = new Assets(
                new List<Vector3>() {
                new Vector3(radius_x*3/4, radius_y/2, radius_z/2),
                new Vector3(-radius_x*3/4,radius_y/2, radius_z/2),
                new Vector3(0,(float) Math.Sqrt(Math.Pow((double)radius_y/2 , 2.0)+Math.Pow((double)radius_x*3/4 , 2.0)), radius_z/2),
                new Vector3(radius_x*3/4, radius_y/2, -radius_z/2),
                new Vector3(-radius_x*3/4,radius_y/2, -radius_z/2),
                new Vector3(0,(float) Math.Sqrt(Math.Pow((double)radius_y/2 , 2.0)+Math.Pow((double)radius_x*3/4 , 2.0)), -radius_z/2)
                },
                new List<uint>() { 
                0,1,2,
                3,4,5,
                0,3,2,
                3,2,5,
                1,2,4,
                2,4,5,
                0,1,3,
                1,4,3,
                },
                new Vector3(153, 60, 9),
                0) ;
            temp_object.setCenter(0, radius_y / 2, 0);
            atap.addChild(temp_object);
            parentObj.addChild(atap);
            #endregion

            #region jendela
            //jendela
            Assets jendela = new Assets();
            temp_object = new Assets(0, new Vector3(207, 251, 255));
            temp_object.createBoxVertices(radius_x * 5 / 16, radius_y / 4, radius_z / 2 , radius_x*0.9f/4, radius_y*0.9f/4, 0.01f);
            jendela.addChild(temp_object);

            temp_object = new Assets(0, new Vector3(207, 251, 255));
            temp_object.createBoxVertices(-radius_x * 5 / 16, radius_y / 4, radius_z / 2 , radius_x*0.9f / 4, radius_y*0.9f / 4, 0.01f);
            jendela.addChild(temp_object);
            parentObj.addChild(jendela);
            #endregion

            #region mailbox
            //mailbox
            temp_object = new Assets(0, new Vector3(125, 45, 1) );
            temp_object.createBoxVertices(-radius_x * 3 / 8, -radius_y *6/ 16, (radius_z *3/4), radius_x / 32, radius_y / 4, radius_z / 32);
            parentObj.addChild(temp_object);

            temp_object = new Assets(0, new Vector3(255, 0, 0) );
            temp_object.createBoxVertices(-radius_x *3/ 8, -radius_y * 4 / 16, (radius_z * 3 / 4), radius_x / 4, radius_y / 8, radius_z / 8);
            parentObj.addChild(temp_object);
            temp_object = new Assets(1, new Vector3(255, 0, 0) );
            temp_object.createCylinder(-radius_x * 3 / 8, -radius_y *3/ 16, (radius_z * 3 / 4), radius_y / 16, radius_y / 16, radius_z / 4);
            temp_object.rotate(temp_object.getCenter(), temp_object._euler[1], 90f);
            parentObj.addChild(temp_object);
            temp_object = new Assets(0, new Vector3(125, 45, 1) );
            temp_object.createBoxVertices(-radius_x * 3 / 8, -radius_y * 6 / 16, (radius_z * 3 / 4), radius_x / 32, radius_y / 4, radius_z / 32);
            parentObj.addChild(temp_object);

            temp_object = new Assets(0, new Vector3(125, 45, 1));
            temp_object.createBoxVertices(-radius_x * 3 / 8, -radius_y * 6 / 16, (radius_z * 3 / 4), radius_x / 16, radius_y / 4, radius_z / 16);
            temp_object.Scaling(new Vector3(0.25f, 0.25f, 0.25f));
            temp_object.Translation(new Vector3(-0.37f, -0.1f, 0.63f));
            parentObj.addChild(temp_object);
            temp_object = new Assets(0, new Vector3(252, 161, 131));
            temp_object.createBoxVertices(-radius_x * 3 / 8, -radius_y * 6 / 16, (radius_z * 3 / 4), radius_x *4/ 16, radius_y* 2/ 16, radius_z / 16);
            temp_object.Scaling(new Vector3(0.25f, 0.25f, 0.25f));
            temp_object.Translation(new Vector3(-0.36f-(radius_x / 32), -0.0555f, 0.63f));
            parentObj.addChild(temp_object);
            #endregion

            parentObj.load(shaderVert, shaderFrag, Size_x, Size_y);
            Translation(1f, 0.2f, -1f);
            parentObj.Scaling(new Vector3(0.8f, 0.8f, 0.8f));
            //_centerPosition = new Vector3(0, 0, 0);
        }

        public override void render(FrameEventArgs args, Matrix4 camera_view, Matrix4 camera_projection)
        {
            base.render(args, camera_view, camera_projection);
            parentObj.render(camera_view, camera_projection);
        }

        public override void changeStatus()
        {
            base.changeStatus();
        }

        public override Vector3 getCenter()
        {
            return base.getCenter();
        }

        public override bool getStatus()
        {
            return base.getStatus();
        }

        public override void resetScale()
        {
            base.resetScale();
        }

        public override void Rotate(Vector3 pivot, int euler, double time)
        {
            base.Rotate(pivot, euler, time);
        }

        public override void Scale(float scaleX, float scaleY, float scaleZ)
        {
            base.Scale(scaleX, scaleY, scaleZ);
        }

        public override void setCenter(float x, float y, float z)
        {
            base.setCenter(x, y, z);
        }

        public override void Translation(float x, float y, float z)
        {
            base.Translation(x, y, z);
        }
    }
}
