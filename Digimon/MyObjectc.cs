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
    internal class MyObject
    {
        public Assets parentObj = new Assets();

        protected Vector3 _centerPosition;
        protected bool status = false; //default tidak rotate dll dari keyboard


        protected Vector3 current_scale = new Vector3(1, 1, 1);

        protected float radius_x;
        protected float radius_y;
        protected float radius_z;
        protected bool statusIdle1;
        protected bool statusIdle2;
        protected Vector3 rotateValue;

        protected float walkSpeed;
        protected float border;
        protected bool walkStatus = true;
        public MyObject()
        {
            setDefault();
        }

        public MyObject(Vector3 centerPosition, bool status = true)
        {
            setDefault();
            this._centerPosition = centerPosition;
            this.status = status;
        }
        public virtual void setDefault()
        {
            _centerPosition = new Vector3(0, 0, 0);
            status = false;
            current_scale = new Vector3(1, 1, 1);
            statusIdle1 = false;
            statusIdle2 = false;
            rotateValue = new Vector3(0, 0, 0);
            walkSpeed = 0.004f;
            border = 2.2f;

        }
        public virtual void load(string shaderVert, string shaderFrag, float Size_x, float Size_y)
        {
        }

        public virtual void render(FrameEventArgs args, Matrix4 camera_view, Matrix4 camera_projection)
        {

        }
        protected virtual void idle2()
        {
            if (isIdle2())
            {
                if(getCenter().X <= -border / 2)
                {
                    walkStatus = true;
                }
                if((getCenter().X >= border / 2))
                {
                    walkStatus = false;
                }
                if (walkStatus)
                { 
                    if (getRotateValue().Y != 90)
                    {
                        Rotate(getCenter(), 1, (450 - getRotateValue().Y) % 360);
                        setRotateValue(new Vector3(0, 90, 0));
                    }
                    Translation(walkSpeed, 0, 0);
                }
                else
                {
                    if (getRotateValue().Y != 270)
                    {
                        Rotate(getCenter(), 1, (630 - getRotateValue().Y) % 360);
                        setRotateValue(new Vector3(0, 270, 0));
                    }
                    Translation(-walkSpeed, 0, 0);
                }
            }
        }
        public virtual void Rotate(Vector3 pivot, int euler, double time)
        {
            parentObj.rotate(pivot, parentObj._euler[euler], (float)time);
        }

        public virtual void Translation(float x, float y, float z)
        {
            Vector3 vector = new Vector3(x, y, z);
            parentObj.Translation(vector);
            _centerPosition += vector;
        }
        public virtual void Scale(float scaleX, float scaleY, float scaleZ)
        {
            Vector3 scale = new Vector3(scaleX, scaleY, scaleZ);
            current_scale *= scale;
            parentObj.Scaling(scale);
        }

        public virtual void resetScale()
        {
            parentObj.Scaling(new Vector3(1 / current_scale.X, 1 / current_scale.Y, 1 / current_scale.Z));
            current_scale = new Vector3(1, 1, 1);
        }
        public virtual void setCenter(float x, float y, float z)
        {
            this._centerPosition.X = x;
            this._centerPosition.Y = y;
            this._centerPosition.Z = z;
        }
        public virtual Vector3 getCenter()
        {
            return (this._centerPosition);
        }

        public virtual void changeStatus()
        {
            this.status = !(this.status);
        }
        public virtual bool getStatus()
        {
            return status;
        }
        public virtual void setStatus(bool status)
        {
            this.status = status;
        }
        public virtual void isIdle1(bool idleStatus)
        {
            this.statusIdle1 = idleStatus;
        }
        public virtual bool isIdle1()
        {
            return this.statusIdle1;
        }
        public virtual void isIdle2(bool idleStatus)
        {
            this.statusIdle2 = idleStatus;
        }
        public virtual bool isIdle2()
        {
            return this.statusIdle2;
        }

        public virtual Vector3 getRotateValue()
        {
            return rotateValue;
        }
        public virtual void setRotateValue(Vector3 value)
        {
            rotateValue = value;
            if (rotateValue.X < 360)
            {
                rotateValue.X += 360;
            }
            else
            {
                rotateValue.X %= 360;
            }
            if (rotateValue.Y < 360)
            {
                rotateValue.Y += 360;
            }
            else
            {
                rotateValue.Y %= 360;
            }
            if (rotateValue.Z < 360)
            {
                rotateValue.Z += 360;
            }
            else
            {
                rotateValue.Z %= 360;
            }
        }
        public virtual void addRotateValue(Vector3 value)
        {
            rotateValue += value;
            if(rotateValue.X < 360)
            {
                rotateValue.X += 360;
            }
            else
            {
                rotateValue.X %= 360;
            }
            if (rotateValue.Y < 360)
            {
                rotateValue.Y += 360;
            }
            else
            {
                rotateValue.Y %= 360;
            }
            if (rotateValue.Z < 360)
            {
                rotateValue.Z += 360;
            }
            else
            {
                rotateValue.Z %= 360;
            }
        }
    }
}
