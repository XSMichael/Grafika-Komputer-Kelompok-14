using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digimon
{
    internal class Ground : MyObject
    {
        Assets rumput;
        Assets cincir;
        public Ground()
        {

        }
        public Ground(Vector3 centerPosition, bool status = true)
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

            parentObj = new Assets(0, new Vector3(209, 126, 25));
            parentObj.createBoxVertices(0, -0.505f, 0, 3.0f, 0.5f, 3.0f);

            temp_object = new Assets(0, new Vector3(102, 204, 0));
            temp_object.createBoxVertices(0, -0.25f, 0, 3.0f, 0.01f, 3.0f);
            parentObj.addChild(temp_object);

            #region rumput
            //Rumput
            temp_object = new Assets(1, new Vector3(128, 255, 0));
            temp_object.createEllipticParaboloid(1.0f, -0.15f, 0.0f, 0.05f, 0.05f, 0.3f);
            temp_object.rotate(temp_object.getCenter(), temp_object._euler[0], 90);
            parentObj.addChild(temp_object);

            temp_object = new Assets(1, new Vector3(128, 255, 0));
            temp_object.createEllipticParaboloid(1.03f, -0.15f, 0.0f, 0.05f, 0.05f, 0.3f);
            temp_object.rotate(temp_object.getCenter(), temp_object._euler[0], 90);
            parentObj.addChild(temp_object);

            temp_object = new Assets(1, new Vector3(128, 255, 0));
            temp_object.createEllipticParaboloid(1.06f, -0.15f, 0.0f, 0.05f, 0.05f, 0.3f);
            temp_object.rotate(temp_object.getCenter(), temp_object._euler[0], 90);
            parentObj.addChild(temp_object);

            //Rumput
            temp_object = new Assets(1, new Vector3(128, 255, 0));
            temp_object.createEllipticParaboloid(-1.0f, -0.15f, -0.3f, 0.05f, 0.05f, 0.3f);
            temp_object.rotate(temp_object.getCenter(), temp_object._euler[0], 90);
            parentObj.addChild(temp_object);

            temp_object = new Assets(1, new Vector3(128, 255, 0));
            temp_object.createEllipticParaboloid(-1.03f, -0.15f, -0.3f, 0.05f, 0.05f, 0.3f);
            temp_object.rotate(temp_object.getCenter(), temp_object._euler[0], 90);
            parentObj.addChild(temp_object);

            temp_object = new Assets(1, new Vector3(128, 255, 0));
            temp_object.createEllipticParaboloid(-1.06f, -0.15f, -0.3f, 0.05f, 0.05f, 0.3f);
            temp_object.rotate(temp_object.getCenter(), temp_object._euler[0], 90);
            parentObj.addChild(temp_object);

            //Rumput
            temp_object = new Assets(1, new Vector3(128, 255, 0));
            temp_object.createEllipticParaboloid(0.3f, -0.15f, 1.0f, 0.05f, 0.05f, 0.3f);
            temp_object.rotate(temp_object.getCenter(), temp_object._euler[0], 90);
            parentObj.addChild(temp_object);

            temp_object = new Assets(1, new Vector3(128, 255, 0));
            temp_object.createEllipticParaboloid(0.33f, -0.15f, 1.0f, 0.05f, 0.05f, 0.3f);
            temp_object.rotate(temp_object.getCenter(), temp_object._euler[0], 90);
            parentObj.addChild(temp_object);

            temp_object = new Assets(1, new Vector3(128, 255, 0));
            temp_object.createEllipticParaboloid(0.36f, -0.15f, 1.0f, 0.05f, 0.05f, 0.3f);
            temp_object.rotate(temp_object.getCenter(), temp_object._euler[0], 90);
            parentObj.addChild(temp_object);

            //Rumput
            temp_object = new Assets(1, new Vector3(128, 255, 0));
            temp_object.createEllipticParaboloid(-0.0f, -0.15f, -1.0f, 0.05f, 0.05f, 0.3f);
            temp_object.rotate(temp_object.getCenter(), temp_object._euler[0], 90);
            parentObj.addChild(temp_object);

            temp_object = new Assets(1, new Vector3(128, 255, 0));
            temp_object.createEllipticParaboloid(-0.03f, -0.15f, -1.0f, 0.05f, 0.05f, 0.3f);
            temp_object.rotate(temp_object.getCenter(), temp_object._euler[0], 90);
            parentObj.addChild(temp_object);

            temp_object = new Assets(1, new Vector3(128, 255, 0));
            temp_object.createEllipticParaboloid(-0.06f, -0.15f, -1.0f, 0.05f, 0.05f, 0.3f);
            temp_object.rotate(temp_object.getCenter(), temp_object._euler[0], 90);
            parentObj.addChild(temp_object);

            //Rumput
            temp_object = new Assets(1, new Vector3(128, 255, 0));
            temp_object.createEllipticParaboloid(0.5f, -0.15f, -0.5f, 0.05f, 0.05f, 0.3f);
            temp_object.rotate(temp_object.getCenter(), temp_object._euler[0], 90);
            parentObj.addChild(temp_object);

            temp_object = new Assets(1, new Vector3(128, 255, 0));
            temp_object.createEllipticParaboloid(0.5f, -0.15f, -0.53f, 0.05f, 0.05f, 0.3f);
            temp_object.rotate(temp_object.getCenter(), temp_object._euler[0], 90);
            parentObj.addChild(temp_object);

            temp_object = new Assets(1, new Vector3(128, 255, 0));
            temp_object.createEllipticParaboloid(0.5f, -0.15f, -0.56f, 0.05f, 0.05f, 0.3f);
            temp_object.rotate(temp_object.getCenter(), temp_object._euler[0], 90);

            parentObj.addChild(temp_object);

            //Rumput
            temp_object = new Assets(1, new Vector3(128, 255, 0));
            temp_object.createEllipticParaboloid(-0.7f, -0.15f, 0.8f, 0.05f, 0.05f, 0.3f);
            temp_object.rotate(temp_object.getCenter(), temp_object._euler[0], 90);
            parentObj.addChild(temp_object);

            temp_object = new Assets(1, new Vector3(128, 255, 0));
            temp_object.createEllipticParaboloid(-0.7f, -0.15f, 0.83f, 0.05f, 0.05f, 0.3f);
            temp_object.rotate(temp_object.getCenter(), temp_object._euler[0], 90);
            parentObj.addChild(temp_object);

            temp_object = new Assets(1, new Vector3(128, 255, 0));
            temp_object.createEllipticParaboloid(-0.7f, -0.15f, 0.86f, 0.05f, 0.05f, 0.3f);
            temp_object.rotate(temp_object.getCenter(), temp_object._euler[0], 90);

            //Rumput
            temp_object = new Assets(1, new Vector3(128, 255, 0));
            temp_object.createEllipticParaboloid(-1.4f, -0.15f, -0.2f, 0.05f, 0.05f, 0.3f);
            temp_object.rotate(temp_object.getCenter(), temp_object._euler[0], 90);
            parentObj.addChild(temp_object);

            temp_object = new Assets(1, new Vector3(128, 255, 0));
            temp_object.createEllipticParaboloid(-1.4f, -0.15f, -0.23f, 0.05f, 0.05f, 0.3f);
            temp_object.rotate(temp_object.getCenter(), temp_object._euler[0], 90);
            parentObj.addChild(temp_object);

            temp_object = new Assets(1, new Vector3(128, 255, 0));
            temp_object.createEllipticParaboloid(-1.4f, -0.15f, -0.26f, 0.05f, 0.05f, 0.3f);
            temp_object.rotate(temp_object.getCenter(), temp_object._euler[0], 90);

            //Rumput
            temp_object = new Assets(1, new Vector3(128, 255, 0));
            temp_object.createEllipticParaboloid(1.4f, -0.15f, -0.2f, 0.05f, 0.05f, 0.3f);
            temp_object.rotate(temp_object.getCenter(), temp_object._euler[0], 90);
            parentObj.addChild(temp_object);

            temp_object = new Assets(1, new Vector3(128, 255, 0));
            temp_object.createEllipticParaboloid(1.4f, -0.15f, -0.23f, 0.05f, 0.05f, 0.3f);
            temp_object.rotate(temp_object.getCenter(), temp_object._euler[0], 90);
            parentObj.addChild(temp_object);

            temp_object = new Assets(1, new Vector3(128, 255, 0));
            temp_object.createEllipticParaboloid(1.4f, -0.15f, -0.26f, 0.05f, 0.05f, 0.3f);
            temp_object.rotate(temp_object.getCenter(), temp_object._euler[0], 90);
            parentObj.addChild(temp_object);

            parentObj.addChild(temp_object);
            #endregion

            #region stone
            //stone
            temp_object = new Assets(1, new Vector3(160, 160, 160));
            temp_object.createEllipsoid(0.3f, -0.23f, 0.0f, 0.05f, 0.02f, 0.05f);
            parentObj.addChild(temp_object);
            temp_object = new Assets(1, new Vector3(160, 160, 160));
            temp_object.createEllipsoid(0.25f, -0.23f, 0.1f, 0.03f, 0.02f, 0.03f);
            parentObj.addChild(temp_object);

            temp_object = new Assets(1, new Vector3(160, 160, 160));
            temp_object.createEllipsoid(-0.8f, -0.23f, -0.7f, 0.05f, 0.05f, 0.05f);
            parentObj.addChild(temp_object);
            temp_object = new Assets(1, new Vector3(160, 160, 160));
            temp_object.createEllipsoid(-0.9f, -0.23f, -0.8f, 0.03f, 0.02f, 0.03f);
            parentObj.addChild(temp_object);

            temp_object = new Assets(1, new Vector3(160, 160, 160));
            temp_object.createEllipsoid(-0.3f, -0.23f, 0.7f, 0.05f, 0.02f, 0.05f);
            parentObj.addChild(temp_object);
            temp_object = new Assets(1, new Vector3(160, 160, 160));
            temp_object.createEllipsoid(-0.25f, -0.23f, 0.8f, 0.03f, 0.02f, 0.03f);
            parentObj.addChild(temp_object);

            temp_object = new Assets(1, new Vector3(160, 160, 160));
            temp_object.createEllipsoid(-1.1f, -0.23f, 1.1f, 0.08f, 0.08f, 0.08f);
            parentObj.addChild(temp_object);
            temp_object = new Assets(1, new Vector3(160, 160, 160));
            temp_object.createEllipsoid(-1.25f, -0.23f, 1.0f, 0.1f, 0.1f, 0.1f);
            parentObj.addChild(temp_object);

            temp_object = new Assets(1, new Vector3(160, 160, 160));
            temp_object.createEllipsoid(1.0f, -0.23f, 1.1f, 0.07f, 0.07f, 0.07f);
            parentObj.addChild(temp_object);
            temp_object = new Assets(1, new Vector3(160, 160, 160));
            temp_object.createEllipsoid(1.25f, -0.23f, 1.0f, 0.1f, 0.1f, 0.1f);
            parentObj.addChild(temp_object);

            //Rumput
            temp_object = new Assets(1, new Vector3(128, 255, 0));
            temp_object.createEllipticParaboloid(1.09f, -0.15f, 1.2f, 0.05f, 0.05f, 0.3f);
            temp_object.rotate(temp_object.getCenter(), temp_object._euler[0], 90);
            parentObj.addChild(temp_object);

            temp_object = new Assets(1, new Vector3(128, 255, 0));
            temp_object.createEllipticParaboloid(1.12f, -0.15f, 1.2f, 0.05f, 0.05f, 0.3f);
            temp_object.rotate(temp_object.getCenter(), temp_object._euler[0], 90);
            parentObj.addChild(temp_object);

            temp_object = new Assets(1, new Vector3(128, 255, 0));
            temp_object.createEllipticParaboloid(1.15f, -0.15f, 1.2f, 0.05f, 0.05f, 0.3f);
            temp_object.rotate(temp_object.getCenter(), temp_object._euler[0], 90);
            parentObj.addChild(temp_object);

            //Rumput
            temp_object = new Assets(1, new Vector3(128, 255, 0));
            temp_object.createEllipticParaboloid(-1.09f, -0.15f, 1.2f, 0.05f, 0.05f, 0.3f);
            temp_object.rotate(temp_object.getCenter(), temp_object._euler[0], 90);
            parentObj.addChild(temp_object);

            temp_object = new Assets(1, new Vector3(128, 255, 0));
            temp_object.createEllipticParaboloid(-1.12f, -0.15f, 1.2f, 0.05f, 0.05f, 0.3f);
            temp_object.rotate(temp_object.getCenter(), temp_object._euler[0], 90);
            parentObj.addChild(temp_object);

            temp_object = new Assets(1, new Vector3(128, 255, 0));
            temp_object.createEllipticParaboloid(-1.15f, -0.15f, 1.2f, 0.05f, 0.05f, 0.3f);
            temp_object.rotate(temp_object.getCenter(), temp_object._euler[0], 90);
            parentObj.addChild(temp_object);
            #endregion

            #region fruit
            //fruit
            temp_object = new Assets(1, new Vector3(255, 128, 0));
            temp_object.createEllipsoid(0.5f, -0.2f, 1.0f, 0.05f, 0.05f, 0.05f);
            parentObj.addChild(temp_object);

            temp_object = new Assets(1, new Vector3(0, 153, 0));
            temp_object.createEllipsoid(0.53f, -0.15f, 1.0f, 0.04f, 0.01f, 0.01f);
            temp_object.rotate(temp_object.getCenter(), temp_object._euler[1], 30);
            parentObj.addChild(temp_object);

            temp_object = new Assets(1, new Vector3(204, 0, 0));
            temp_object.createEllipsoid(-0.7f, -0.2f, 0f, 0.05f, 0.05f, 0.05f);
            parentObj.addChild(temp_object);

            temp_object = new Assets(1, new Vector3(0, 153, 0));
            temp_object.createEllipsoid(-0.73f, -0.15f, 0f, 0.04f, 0.01f, 0.01f);
            temp_object.rotate(temp_object.getCenter(), temp_object._euler[1], 30);
            parentObj.addChild(temp_object);

            temp_object = new Assets(1, new Vector3(239, 226, 38));
            temp_object.createEllipsoid(-0.7f, -0.2f, 1.0f, 0.05f, 0.05f, 0.05f);
            parentObj.addChild(temp_object);

            temp_object = new Assets(1, new Vector3(0, 153, 0));
            temp_object.createEllipsoid(-0.73f, -0.15f, 1.0f, 0.04f, 0.01f, 0.01f);
            temp_object.rotate(temp_object.getCenter(), temp_object._euler[1], 30);
            parentObj.addChild(temp_object);
            #endregion

            #region pagar
            //Pagar 1
            //Samping kanan
            temp_object = new Assets(0, new Vector3(123, 63, 0));
            temp_object.createBoxVertices(-0.5f, -0.1f, -1.45f, 0.05f, 0.35f, 0.05f);
            parentObj.addChild(temp_object);

            //Samping kiri
            temp_object = new Assets(0, new Vector3(123, 63, 0));
            temp_object.createBoxVertices(-1.45f, -0.1f, -1.45f, 0.05f, 0.35f, 0.05f);
            parentObj.addChild(temp_object);

            //Bawah
            temp_object = new Assets(0, new Vector3(123, 63, 0));
            temp_object.createBoxVertices(-0.975f, -0.15f, -1.48f, 1f, 0.05f, 0.02f);
            parentObj.addChild(temp_object);

            //Atas
            temp_object = new Assets(0, new Vector3(123, 63, 0));
            temp_object.createBoxVertices(-0.975f, -0f, -1.48f, 1f, 0.05f, 0.02f);
            parentObj.addChild(temp_object);

            //Pagar 2
            temp_object = new Assets(0, new Vector3(123, 63, 0));
            temp_object.createBoxVertices(0.5f, -0.1f, -1.45f, 0.05f, 0.35f, 0.05f);
            parentObj.addChild(temp_object);

            temp_object = new Assets(0, new Vector3(123, 63, 0));
            temp_object.createBoxVertices(1.45f, -0.1f, -1.45f, 0.05f, 0.35f, 0.05f);
            parentObj.addChild(temp_object);

            temp_object = new Assets(0, new Vector3(123, 63, 0));
            temp_object.createBoxVertices(0.975f, -0.15f, -1.48f, 1f, 0.05f, 0.02f);
            parentObj.addChild(temp_object);

            temp_object = new Assets(0, new Vector3(123, 63, 0));
            temp_object.createBoxVertices(0.975f, -0f, -1.48f, 1f, 0.05f, 0.02f);
            parentObj.addChild(temp_object);


            //Pagar 3
            temp_object = new Assets(0, new Vector3(123, 63, 0));
            temp_object.createBoxVertices(1.45f, -0.1f, 0f, 0.05f, 0.35f, 0.05f);
            parentObj.addChild(temp_object);

            temp_object = new Assets(0, new Vector3(123, 63, 0));
            temp_object.createBoxVertices(1.45f, -0.1f, 1f, 0.05f, 0.35f, 0.05f);
            parentObj.addChild(temp_object);

            temp_object = new Assets(0, new Vector3(123, 63, 0));
            temp_object.createBoxVertices(1.48f, -0.15f, 0.5f, 0.02f, 0.05f, 1f);
            parentObj.addChild(temp_object);

            temp_object = new Assets(0, new Vector3(123, 63, 0));
            temp_object.createBoxVertices(1.48f, -0f, 0.5f, 0.02f, 0.05f, 1f);
            parentObj.addChild(temp_object);

            //Pagar 4
            temp_object = new Assets(0, new Vector3(123, 63, 0));
            temp_object.createBoxVertices(-1.45f, -0.1f, 0f, 0.05f, 0.35f, 0.05f);
            parentObj.addChild(temp_object);

            temp_object = new Assets(0, new Vector3(123, 63, 0));
            temp_object.createBoxVertices(-1.45f, -0.1f, 1f, 0.05f, 0.35f, 0.05f);
            parentObj.addChild(temp_object);

            temp_object = new Assets(0, new Vector3(123, 63, 0));
            temp_object.createBoxVertices(-1.48f, -0.15f, 0.5f, 0.02f, 0.05f, 1f);
            parentObj.addChild(temp_object);

            temp_object = new Assets(0, new Vector3(123, 63, 0));
            temp_object.createBoxVertices(-1.48f, -0f, 0.5f, 0.02f, 0.05f, 1f);
            parentObj.addChild(temp_object);
            #endregion

            #region pohon
            //Batang
            temp_object = new Assets(1, new Vector3(100, 49, 11));
            //temp_object.createBoxVertices(-0.6f, 0.3f, -0.5f, 0.1f, 1f, 0.1f);
            temp_object.createCylinder(-0.6f, 0.3f, -0.5f, 0.08f, 0.08f, 1f);
            temp_object.rotate(temp_object.getCenter(), temp_object._euler[0], 90);
            parentObj.addChild(temp_object);

            temp_object = new Assets(1, new Vector3(100, 49, 11));
            temp_object.createCylinder(-0.4f, 0.35f, -0.5f, 0.05f, 0.25f, 0.05f);
            temp_object.rotate(temp_object.getCenter(), temp_object._euler[2], 120);
            parentObj.addChild(temp_object);

            //Right
            temp_object = new Assets(1, new Vector3(100, 49, 11));
            temp_object.createCylinder(-0.75f, 0.65f, -0.5f, 0.05f, 0.2f, 0.05f);
            temp_object.rotate(temp_object.getCenter(), temp_object._euler[2], 30);
            parentObj.addChild(temp_object);

            //Daun
            temp_object = new Assets(1, new Vector3(16, 119, 12));
            temp_object.createEllipsoid(-0.7f, 0.95f, -0.5f, 0.65f, 0.2f, 0.5f);
            parentObj.addChild(temp_object);

            temp_object = new Assets(1, new Vector3(16, 119, 12));
            temp_object.createEllipsoid(-0.2f, 0.5f, -0.5f, 0.25f, 0.15f, 0.2f);
            temp_object.rotate(temp_object.getCenter(), temp_object._euler[2], 165);
            parentObj.addChild(temp_object);


            //buah 1
            temp_object = new Assets(1, new Vector3(255, 128, 0));
            temp_object.createEllipsoid(-0.75f, 0.8f, -0.05f, 0.05f, 0.05f, 0.05f);
            parentObj.addChild(temp_object);

            temp_object = new Assets(1, new Vector3(0, 153, 0));
            temp_object.createEllipsoid(-0.78f, 0.85f, -0.05f, 0.04f, 0.01f, 0.01f);
            temp_object.rotate(temp_object.getCenter(), temp_object._euler[1], 30);
            parentObj.addChild(temp_object);

            //buah 2
            temp_object = new Assets(1, new Vector3(204, 0, 0));
            temp_object.createEllipsoid(-0.2f, 0.4f, -0.31f, 0.05f, 0.05f, 0.05f);
            parentObj.addChild(temp_object);

            temp_object = new Assets(1, new Vector3(0, 153, 0));
            temp_object.createEllipsoid(-0.23f, 0.45f, -0.31f, 0.04f, 0.01f, 0.01f);
            temp_object.rotate(temp_object.getCenter(), temp_object._euler[1], 30);
            parentObj.addChild(temp_object);

            //buah 3 
            temp_object = new Assets(1, new Vector3(239, 226, 38));
            temp_object.createEllipsoid(-1f, 0.73f, -0.50f, 0.05f, 0.05f, 0.05f);
            parentObj.addChild(temp_object);

            temp_object = new Assets(1, new Vector3(0, 153, 0));
            temp_object.createEllipsoid(-1.03f, 0.78f, -0.50f, 0.04f, 0.01f, 0.01f);
            temp_object.rotate(temp_object.getCenter(), temp_object._euler[1], 30);
            parentObj.addChild(temp_object);

            #endregion

            #region cincir angin
            //Cincir Angin
            //Tiang
            temp_object = new Assets(1, new Vector3(142, 80, 33));
            temp_object.createCylinder(-1.1f, 0.0f, 1.0f, 0.01f, 0.01f, 0.6f);
            temp_object.rotate(temp_object.getCenter(), temp_object._euler[0], 90);
            parentObj.addChild(temp_object);

            //Cincir
            cincir = new Assets(0, new Vector3(188, 107, 46));
            cincir.createBoxVertices(-1.1f, 0.3f, 1.02f, 0.07f, 0.4f, 0.01f);
            parentObj.addChild(cincir);

            temp_object = new Assets(0, new Vector3(188, 107, 46));
            temp_object.createBoxVertices(-1.1f, 0.3f, 1.02f, 0.07f, 0.4f, 0.01f);
            temp_object.rotate(temp_object.getCenter(), temp_object._euler[2], 90);
            cincir.addChild(temp_object);

            //paku
            temp_object = new Assets(1, new Vector3(216, 149, 98));
            temp_object.createCylinder(-1.1f, 0.3f, 1.0f, 0.03f, 0.03f, 0.08f);
            cincir.addChild(temp_object);

            //buntut
            temp_object = new Assets(2, new Vector3(216, 149, 98));
            temp_object.createCylinder(-1.1f, 0.3f, 0.85f, 0.01f, 0.01f, 0.3f);
            parentObj.addChild(temp_object);

            temp_object = new Assets(2, new Vector3(216, 149, 98));
            temp_object.createCylinder(-1.1f, 0.3f, 0.85f, 0.01f, 0.01f, 0.3f);
            parentObj.addChild(temp_object);

            temp_object = new Assets(0, new Vector3(216, 149, 98));
            temp_object.createBoxVertices(-1.1f, 0.3f, 0.7f, 0.03f, 0.12f, 0.02f);
            temp_object.rotate(cincir.getCenter(), temp_object._euler[2], 40);
            cincir.addChild(temp_object);


            #endregion
            parentObj.load(shaderVert, shaderFrag, Size_x, Size_y);
            Scale(1.0f, 1.0f, 1.0f);
            Translation(0.0f, 0.0f, 0.0f);
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
                cincir.rotate(cincir.getCenter(), cincir._euler[2], 1.3f);
            }
        }
    }
}
