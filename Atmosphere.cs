using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digimon
{
    internal class Atmosphere :MyObject
    {
        public Atmosphere()
        {

        }
        public Atmosphere(Vector3 centerPosition, bool status = true)
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

            parentObj = new Assets(0, new Vector4(0, 153, 221,0.1f));
            parentObj.createBoxVertices(0, 0.495f, 0, 3.0f, 2.502f, 3.0f);



            parentObj.load(shaderVert, shaderFrag, Size_x, Size_y);
            Scale(1.0f, 1.0f, 1.0f);
            Translation(0.0f, 0.0f, 0.0f);

        }

        public override void render(FrameEventArgs args, Matrix4 camera_view, Matrix4 camera_projection)
        {
            base.render(args, camera_view, camera_projection);
            parentObj.render(camera_view, camera_projection);
        }
        
    }
}
