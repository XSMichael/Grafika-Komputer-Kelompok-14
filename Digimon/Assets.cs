using LearnOpenTK.Common;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digimon
{
    internal class Assets
    {
        protected List<Vector3> _vertices = new List<Vector3>();
        protected List<uint> _indices = new List<uint>();

        public List<Assets> Child;
        protected Vector3 _color;
        protected float alphaColor;

        protected int _vertexBufferObject;
        protected int _vertexArrayObject;
        protected int _elementBufferObject;
        protected Shader _Shader;

        protected Vector3 _centerPosition = new Vector3(0, 0, 0);
        public List<Vector3> _euler = new List<Vector3>(); //sumbu rotasi

        Matrix4 _model;
        protected int type = 0;

        public int indexs;
        int[] _pascal;

        public Assets(List<Vector3> vertices, List<uint> indices, Vector3 color, int type)
        {
            this._vertices = vertices;
            this._indices = indices;
            this._color = color;
            this.setType(type);
            setdefault();
        }
        public Assets(int type, Vector3 color)
        {
            this._vertices = new List<Vector3>();
            this._indices = new List<uint>();
            this._color = color;
            this.setType(type);
            setdefault();

        }

        public Assets(int type, Vector4 color)
        {
            this._vertices = new List<Vector3>();
            this._indices = new List<uint>();
            this._color = new Vector3(color.X,color.Y,color.Z);
            this.setType(type);
            setdefault();
            this.alphaColor = color.W;
        }

        public Assets(int type)
        {
            _vertices = new List<Vector3>();
            _indices = new List<uint>();
            _color = new Vector3( 255, 0, 0 );
            this.setType(type);
            setdefault();
        }
        public Assets(Assets aset)
        {
            setVertices(aset.getVertices());
            _indices.Clear();
            _indices.AddRange(aset._indices);
            setdefault();
            _color = aset._color;
            alphaColor = aset.alphaColor;
            indexs = aset.indexs;
            _model = aset._model;
            setCenter(aset.getCenter().X, aset.getCenter().Y, aset.getCenter().Z);
            setType(aset.getType());
            foreach(var child in aset.Child)
            {
                Child.Add(new Assets(child));
            }
            
        }
        public Assets()
        {
            _vertices = new List<Vector3>();
            _indices = new List<uint>();
            _color = new Vector3(255, 0, 0);
            this.setType(1);
            setdefault();
        }
        public virtual void setdefault()
        {
            _centerPosition = new Vector3(0, 0, 0);

            _euler = new List<Vector3>();
            //sumbu X
            _euler.Add(new Vector3(1, 0, 0));
            //sumbu y
            _euler.Add(new Vector3(0, 1, 0));
            //sumbu z
            _euler.Add(new Vector3(0, 0, 1));
            Child = new List<Assets>();

            _model = Matrix4.Identity;

            _pascal = new int[0];

            indexs = 0;
            _color.X = _color.X / 255f;
            _color.Y = _color.Y / 255f;
            _color.Z = _color.Z / 255f;
            this.alphaColor = 1; //default
        }

        public virtual void load(string shaderVert, string shaderFrag, float Size_x, float Size_y)
        {
            //inisialisasi
            _vertexBufferObject = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, _vertexBufferObject);
            GL.BufferData(BufferTarget.ArrayBuffer, _vertices.Count * Vector3.SizeInBytes, _vertices.ToArray(), BufferUsageHint.StaticDraw);
            _vertexArrayObject = GL.GenVertexArray();
            GL.BindVertexArray(_vertexArrayObject);

            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 3 * sizeof(float), 0);
            GL.EnableVertexAttribArray(0);


            if (_indices.Count != 0)
            {
                _elementBufferObject = GL.GenBuffer();
                GL.BindBuffer(BufferTarget.ElementArrayBuffer, _elementBufferObject);

                GL.BufferData(BufferTarget.ElementArrayBuffer, _indices.Count * sizeof(uint), _indices.ToArray(), BufferUsageHint.StaticDraw);
            }
            foreach (var item in Child)
            {
                item.load(shaderVert, shaderFrag, Size_x, Size_y);
            }
            _Shader = new Shader(shaderVert, shaderFrag);
            _Shader.Use();
        }

        public virtual void render(Matrix4 camera_view, Matrix4 camera_projection)
        {
            _Shader.Use();
            GL.BindVertexArray(_vertexArrayObject);

            if (this.type == 0) //Triangles
            {
                if (_indices.Count != 0)
                {
                    //DrawElement(gambar apa, gambar berapa kali, tipe data dalam indices, indices di ambil dari index ke brp)
                    GL.DrawElements(PrimitiveType.Triangles, _indices.Count, DrawElementsType.UnsignedInt, 0);
                }
                else
                {
                    GL.DrawArrays(PrimitiveType.Triangles, 0, 3);
                }
            }
            else if (this.type == 1) //TriangleFan
            {
                GL.DrawArrays(PrimitiveType.TriangleFan, 0, (int)(_vertices.Count));
                //triangleFan bakal ngegambar segitiga, tapi segitiga selanjutnya bisa pakai sisi segitiga sebelumnya jadi tidak perlu 3 titik
            }
            else if (this.type == 2) //lineStrip
            {
                //soalnya di bezier ini variabel indeks itu tidak punya isi
                GL.DrawArrays(PrimitiveType.LineStrip, 0, (int)(_vertices.Count));
            }
            else if (this.type == 3) //lines
            {
                //soalnya di bezier ini variabel indeks itu tidak punya isi
                GL.DrawArrays(PrimitiveType.Lines, 0, (int)(_vertices.Count));
            }
            else if (this.type == 4) //lines pakai index
            {
                //lines hanya 2 titik, jika linestrip bisa pakai titik sebelumnya
                GL.DrawArrays(PrimitiveType.LineStrip, 0, indexs);
            }
            //set uniform 

            _Shader.SetMatrix4("model", _model); //mengatur point of view object
            _Shader.SetMatrix4("view", camera_view);
            _Shader.SetMatrix4("projection", camera_projection);
            _Shader.SetVector3("uniformColor", _color);
            _Shader.SetFloat("alphaColor", alphaColor);

            foreach (var item in Child)
            {
                item.render(camera_view, camera_projection);
            }
        }

        #region Create

        public void createCircle(float center_x, float center_y, float center_z, float _radiusX, float _radiusY)
        {
            this.setCenter(center_x, center_y, center_z);
            Vector3 temp_vector;
            for (int i = 0; i < 360; i++)
            {

                double degInRad = i * Math.PI / 180; //i = derajat , *PI/180 untuk ubah ke radian
                //x
                temp_vector.X = _radiusX * (float)Math.Cos(degInRad) + center_x;
                //y
                temp_vector.Y = _radiusY * (float)Math.Sin(degInRad) + center_y;
                //z
                temp_vector.Z = center_z;

                _vertices.Add(temp_vector);
            }

            //titik awal
            //x
            temp_vector.X = _radiusX * (float)Math.Cos(Math.PI / 180) + center_x;
            //y
            temp_vector.Y = _radiusY * (float)Math.Sin(Math.PI / 180) + center_y;
            //z
            temp_vector.Z = center_z;

            _vertices.Add(temp_vector);
        }
        public void createCircle2(float center_x, float center_y, float center_z, float _radiusX, float _radiusY, bool type)
        {
            this.setCenter(center_x, center_y, center_z);
            Vector3 temp_vector;
            for (int i = 0; i < 180; i++)
            {

                double degInRad = i * Math.PI / 180; //i = derajat , *PI/180 untuk ubah ke radian
                //x
                temp_vector.X = _radiusX * (float)Math.Cos(degInRad) + center_x;
                //y
                temp_vector.Y = _radiusY * (float)Math.Sin(degInRad) + center_y;
                //z
                temp_vector.Z = center_z;

                _vertices.Add(temp_vector);
            }

            if (type)
            {
                //titik awal
                //x
                temp_vector.X = _radiusX * (float)Math.Cos(Math.PI / 180) + center_x;
                //y
                temp_vector.Y = _radiusY * (float)Math.Sin(Math.PI / 180) + center_y;
                //z
                temp_vector.Z = center_z;

                _vertices.Add(temp_vector);
            }
            
        }
        public List<Vector3> createCurveBezier()
        {
            List<Vector3> _vertices_bezier = new List<Vector3>();
            List<int> pascal = getRow(indexs - 1);
            _pascal = pascal.ToArray();

            for (float t = 0; t <= 1.0f; t += 0.005f)//increment ini semakin kecil semakin presisi
            {
                Vector3 p = getP(indexs, t);
                _vertices_bezier.Add(p);
            }

            return _vertices_bezier;
        }

        public List<int> getRow(int rowIndex)
        {
            List<int> currow = new List<int>();
            //------
            currow.Add(1);
            if (rowIndex == 0)
            {
                return currow;
            }
            //-----
            List<int> prev = getRow(rowIndex - 1);
            for (int i = 1; i < prev.Count; i++)
            {
                int curr = prev[i - 1] + prev[i];
                currow.Add(curr);
            }
            currow.Add(1);
            return currow;
        }

        public Vector3 getP(int n, float t)
        {
            Vector3 p = new Vector3(0, 0, 0); //start selalu dari 0,0,0
            float k;
            for (int i = 0; i < n; i++)
            {
                k = (float)Math.Pow((1 - t), n - i - 1) * (float)Math.Pow(t, i) * _pascal[i];
                p.X += k * _vertices[i].X;
                p.Y += k * _vertices[i].Y;
                p.Z += k * _vertices[i].Z;
            }

            return p;
        }

        public void createBox()
        {
            //FRONT FACE
            //SEGITIGA FRONT 1
            _vertices.Add(new Vector3(-0.5f, -0.5f, -0.5f));
            _vertices.Add(new Vector3(0.5f, -0.5f, -0.5f));
            _vertices.Add(new Vector3(0.5f, 0.5f, -0.5f));
            //SEGITIGA FRONT 2
            _vertices.Add(new Vector3(0.5f, 0.5f, -0.5f));
            _vertices.Add(new Vector3(-0.5f, 0.5f, -0.5f));
            _vertices.Add(new Vector3(-0.5f, -0.5f, -0.5f));

            //BACK FACE
            //SEGITIGA BACK 1
            _vertices.Add(new Vector3(-0.5f, -0.5f, 0.5f));
            _vertices.Add(new Vector3(0.5f, -0.5f, 0.5f));
            _vertices.Add(new Vector3(0.5f, 0.5f, 0.5f));
            //SEGITIGA BACK 2
            _vertices.Add(new Vector3(0.5f, 0.5f, 0.5f));
            _vertices.Add(new Vector3(-0.5f, 0.5f, 0.5f));
            _vertices.Add(new Vector3(-0.5f, -0.5f, 0.5f));
            //LEFT FACE
            //SEGITIGA LEFT 1
            _vertices.Add(new Vector3(-0.5f, 0.5f, 0.5f));
            _vertices.Add(new Vector3(-0.5f, 0.5f, -0.5f));
            _vertices.Add(new Vector3(-0.5f, -0.5f, -0.5f));
            //SEGITIGA LEFT 2
            _vertices.Add(new Vector3(-0.5f, -0.5f, -0.5f));
            _vertices.Add(new Vector3(-0.5f, -0.5f, 0.5f));
            _vertices.Add(new Vector3(-0.5f, 0.5f, 0.5f));
            //RIGHT FACE
            //SEGITIGA RIGHT 1
            _vertices.Add(new Vector3(0.5f, 0.5f, 0.5f));
            _vertices.Add(new Vector3(0.5f, 0.5f, -0.5f));
            _vertices.Add(new Vector3(0.5f, -0.5f, -0.5f));
            //SEGITIGA LEFT 2
            _vertices.Add(new Vector3(0.5f, -0.5f, -0.5f));
            _vertices.Add(new Vector3(0.5f, -0.5f, 0.5f));
            _vertices.Add(new Vector3(0.5f, 0.5f, 0.5f));
            //BOTTOM FACE
            //SEGITIGA BOTTOM 1
            _vertices.Add(new Vector3(-0.5f, -0.5f, -0.5f));
            _vertices.Add(new Vector3(0.5f, -0.5f, -0.5f));
            _vertices.Add(new Vector3(0.5f, -0.5f, 0.5f));
            //SEGITIGA BOTTOM 2
            _vertices.Add(new Vector3(0.5f, -0.5f, 0.5f));
            _vertices.Add(new Vector3(-0.5f, -0.5f, 0.5f));
            _vertices.Add(new Vector3(-0.5f, -0.5f, -0.5f));
            //FRONT FACE
            //SEGITIGA BOTTOM 1
            _vertices.Add(new Vector3(-0.5f, 0.5f, -0.5f));
            _vertices.Add(new Vector3(0.5f, 0.5f, -0.5f));
            _vertices.Add(new Vector3(0.5f, 0.5f, 0.5f));
            //SEGITIGA BOTTOM 2
            _vertices.Add(new Vector3(0.5f, 0.5f, 0.5f));
            _vertices.Add(new Vector3(-0.5f, 0.5f, 0.5f));
            _vertices.Add(new Vector3(-0.5f, 0.5f, -0.5f));

        }

        public void createBoxVertices(float center_x, float center_y, float center_z, float length_x, float length_y, float length_z)
        {
            this.setCenter(center_x, center_y, center_z);
            Vector3 temp_vector;

            //TITIK 1
            temp_vector.X = center_x - length_x / 2.0f;
            temp_vector.Y = center_y + length_y / 2.0f;
            temp_vector.Z = center_z - length_z / 2.0f;
            _vertices.Add(temp_vector);
            //TITIK 2
            temp_vector.X = center_x + length_x / 2.0f;
            temp_vector.Y = center_y + length_y / 2.0f;
            temp_vector.Z = center_z - length_z / 2.0f;
            _vertices.Add(temp_vector);
            //TITIK 3
            temp_vector.X = center_x - length_x / 2.0f;
            temp_vector.Y = center_y - length_y / 2.0f;
            temp_vector.Z = center_z - length_z / 2.0f;
            _vertices.Add(temp_vector);
            //TITIK 4
            temp_vector.X = center_x + length_x / 2.0f;
            temp_vector.Y = center_y - length_y / 2.0f;
            temp_vector.Z = center_z - length_z / 2.0f;
            _vertices.Add(temp_vector);
            //TITIK 5
            temp_vector.X = center_x - length_x / 2.0f;
            temp_vector.Y = center_y + length_y / 2.0f;
            temp_vector.Z = center_z + length_z / 2.0f;
            _vertices.Add(temp_vector);
            //TITIK 6
            temp_vector.X = center_x + length_x / 2.0f;
            temp_vector.Y = center_y + length_y / 2.0f;
            temp_vector.Z = center_z + length_z / 2.0f;
            _vertices.Add(temp_vector);
            //TITIK 7
            temp_vector.X = center_x - length_x / 2.0f;
            temp_vector.Y = center_y - length_y / 2.0f;
            temp_vector.Z = center_z + length_z / 2.0f;
            _vertices.Add(temp_vector);
            //TITIK 8
            temp_vector.X = center_x + length_x / 2.0f;
            temp_vector.Y = center_y - length_y / 2.0f;
            temp_vector.Z = center_z + length_z / 2.0f;
            _vertices.Add(temp_vector);

            _indices = new List<uint>
            {
                //SEGITIGA DEPAN 1
                0,1,2,
                //SEGITIGA DEPAN 2
                1,2,3,
                //SEGITIGA ATAS 1
                0,4,5,
                //SEGITIGA ATAS 2
                0,1,5,
                //SEGITIGA KANAN 1
                1,3,5,
                //SEGITIGA KANAN 2
                3,5,7,
                //SEGITIGA KIRI 1
                0,2,4,
                //SEGITIGA KIRI 2
                2,4,6,
                //SEGITIGA BELAKANG 1
                4,5,6,
                //SEGITIGA BELAKANG 2
                5,6,7,
                //SEGITIGA BAWAH 1
                2,3,6,
                //SEGITIGA BAWAH 2
                3,6,7
            };
        }

        public void createCylinder(float center_x, float center_y, float center_z, float _radiusX, float _radiusY, float height)
        {
            for (float v = center_z - (height / 2); v <= (height / 2) + center_z; v += 0.001f)
            {
                this.createCircle(center_x, center_y, v, _radiusX, _radiusY);
            }
            this.setCenter(center_x, center_y, center_z);
        }
        public void createCylinder2(float center_x, float center_y, float center_z, float _radiusX, float _radiusY, float height)
        {
            for (float v = center_z - (height / 2); v <= (height / 2) + center_z; v += 0.001f)
            {
                this.createCircle2(center_x, center_y, v, _radiusX, _radiusY, true);
            }
            this.setCenter(center_x, center_y, center_z);
        }
        public void createEllipsoid(float center_x, float center_y, float center_z, float _radiusX, float _radiusY, float _radiusZ)
        {
            this.setCenter(center_x, center_y, center_z);
            Vector3 temp_vector;
            float _pi = (float)Math.PI;

            
            for (float v = -_pi / 2; v <= _pi / 2; v += 0.001f)
            {
                for (float u = -_pi; u <= _pi; u += (_pi / 180))
                {
                    temp_vector.X = center_x + _radiusX * (float)Math.Cos(v) * (float)Math.Cos(u);
                    temp_vector.Y = center_y + _radiusY * (float)Math.Cos(v) * (float)Math.Sin(u);
                    temp_vector.Z = center_z + _radiusZ * (float)Math.Sin(v);
                    _vertices.Add(temp_vector);
                }
            }
        }

        public void createEllipticParaboloid(float center_x, float center_y, float center_z, float _radiusX, float _radiusY, float _v)
        {

            this.setCenter(center_x, center_y, center_z);
            Vector3 temp_vector = new Vector3();
            float _pi = (float)Math.PI;


            for (float v = 0; v <= _v; v += 0.01f)
            {
                for (float u = -_pi; u <= _pi; u += (_pi / 180))
                {
                    temp_vector.X = center_x + _radiusX * v * (float)Math.Cos(u);
                    temp_vector.Y = center_y + _radiusY * v * (float)Math.Sin(u);
                    temp_vector.Z = center_z + v * v;
                    _vertices.Add(temp_vector);
                }
            }
        }
        public void createEllipticParaboloid(float center_x, float center_y, float center_z, float _radiusX, float _radiusY,float _v0, float _v)
        {

            this.setCenter(center_x, center_y, center_z);
            Vector3 temp_vector = new Vector3();
            float _pi = (float)Math.PI;


            for (float v = _v0; v <= _v; v += 0.01f)
            {
                for (float u = -_pi; u <= _pi; u += (_pi / 180))
                {
                    temp_vector.X = center_x + _radiusX * v * (float)Math.Cos(u);
                    temp_vector.Y = center_y + _radiusY * v * (float)Math.Sin(u);
                    temp_vector.Z = center_z + v * v;
                    _vertices.Add(temp_vector);
                }
            }
        }


        #endregion

        #region transforms
        public void rotate(Vector3 pivot, Vector3 vector, float angle)
        {
            var radAngle = MathHelper.DegreesToRadians(angle);

            var arbRotationMatrix = new Matrix4
                (
                new Vector4((float)(Math.Cos(radAngle) + Math.Pow(vector.X, 2.0f) * (1.0f - Math.Cos(radAngle))), (float)(vector.X * vector.Y * (1.0f - Math.Cos(radAngle)) + vector.Z * Math.Sin(radAngle)), (float)(vector.X * vector.Z * (1.0f - Math.Cos(radAngle)) - vector.Y * Math.Sin(radAngle)), 0),
                new Vector4((float)(vector.X * vector.Y * (1.0f - Math.Cos(radAngle)) - vector.Z * Math.Sin(radAngle)), (float)(Math.Cos(radAngle) + Math.Pow(vector.Y, 2.0f) * (1.0f - Math.Cos(radAngle))), (float)(vector.Y * vector.Z * (1.0f - Math.Cos(radAngle)) + vector.X * Math.Sin(radAngle)), 0),
                new Vector4((float)(vector.X * vector.Z * (1.0f - Math.Cos(radAngle)) + vector.Y * Math.Sin(radAngle)), (float)(vector.Y * vector.Z * (1.0f - Math.Cos(radAngle)) - vector.X * Math.Sin(radAngle)), (float)(Math.Cos(radAngle) + Math.Pow(vector.Z, 2.0f) * (1.0f - Math.Cos(radAngle))), 0),
                Vector4.UnitW
                );

            _model *= Matrix4.CreateTranslation(-pivot);
            _model *= arbRotationMatrix;
            _model *= Matrix4.CreateTranslation(pivot);

            for (int i = 0; i < 3; i++)
            {
                _euler[i] = Vector3.Normalize(getRotationResult(pivot, vector, radAngle, _euler[i], true));
            }

            _centerPosition = getRotationResult(pivot, vector, radAngle, _centerPosition);

            foreach (var i in Child)
            {
                i.rotate(pivot, vector, angle);
            }
        }

        public Vector3 getRotationResult(Vector3 pivot, Vector3 vector, float angle, Vector3 point, bool isEuler = false)
        {
            Vector3 temp, newPosition;

            if (isEuler)
            {
                temp = point;
            }
            else
            {
                temp = point - pivot;
            }

            newPosition.X =
                temp.X * (float)(Math.Cos(angle) + Math.Pow(vector.X, 2.0f) * (1.0f - Math.Cos(angle))) +
                temp.Y * (float)(vector.X * vector.Y * (1.0f - Math.Cos(angle)) - vector.Z * Math.Sin(angle)) +
                temp.Z * (float)(vector.X * vector.Z * (1.0f - Math.Cos(angle)) + vector.Y * Math.Sin(angle));

            newPosition.Y =
                temp.X * (float)(vector.X * vector.Y * (1.0f - Math.Cos(angle)) + vector.Z * Math.Sin(angle)) +
                temp.Y * (float)(Math.Cos(angle) + Math.Pow(vector.Y, 2.0f) * (1.0f - Math.Cos(angle))) +
                temp.Z * (float)(vector.Y * vector.Z * (1.0f - Math.Cos(angle)) - vector.X * Math.Sin(angle));

            newPosition.Z =
                temp.X * (float)(vector.X * vector.Z * (1.0f - Math.Cos(angle)) - vector.Y * Math.Sin(angle)) +
                temp.Y * (float)(vector.Y * vector.Z * (1.0f - Math.Cos(angle)) + vector.X * Math.Sin(angle)) +
                temp.Z * (float)(Math.Cos(angle) + Math.Pow(vector.Z, 2.0f) * (1.0f - Math.Cos(angle)));

            if (isEuler)
            {
                temp = newPosition;
            }
            else
            {
                temp = newPosition + pivot;
            }
            return temp;
        }

        public void Translation(Vector3 vec)
        {
            _model *= Matrix4.CreateTranslation(vec);
            _centerPosition.X += vec.X;
            _centerPosition.Y += vec.Y;
            _centerPosition.Z += vec.Z;

            foreach (var i in Child)
            {
                i.Translation(vec);
            }
        }

        public void Scaling(Vector3 vec)
        {
            _model *= Matrix4.CreateTranslation(-_centerPosition);
            _model *= Matrix4.CreateScale(vec);
            _centerPosition *= vec;
            _model *= Matrix4.CreateTranslation(_centerPosition);

            foreach (var i in Child)
            {
                i.Scaling(vec);
            }
        }
        #endregion

        

        #region vertices
        //Vertices
        public virtual void setVertices(List<Vector3> _temp)
        {
            _vertices.Clear();
            _vertices.AddRange(_temp);
            indexs = _temp.Count;
        }
        public virtual List<Vector3> getVertices()
        {
            return _vertices;
        }
        public virtual int getVerticesLength()
        {
            if (_vertices != null)
            {
                return (_vertices.Count);
            }
            return 0; //jika data tidak ada
        }
        public void addVertices(float _x, float _y, float _z)
        {
            this._vertices.Add(new Vector3(_x, _y, _z));
            indexs++;

            GL.BufferData(BufferTarget.ArrayBuffer, _vertices.Count * Vector3.SizeInBytes, _vertices.ToArray(), BufferUsageHint.StaticDraw);
            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 3 * sizeof(float), 0);
        }
        #endregion

        #region child
        //Child
        public virtual void setChild(List<Assets> Childs)
        {
            this.Child.Clear();
            this.Child.AddRange(Childs);
        }

        public virtual void addChild(Assets Child)
        {
            this.Child.Add(Child);
        }
        #endregion

        #region renderType
        //Render Type
        public virtual void setType(int type)
        {
            if (type < 0)
            {
                type = 0;
            }
            else if (type > 4)
            {
                type = 0;
            }
            this.type = type;
        }
        public virtual int getType()
        {
            return this.type;
        }
        #endregion

        #region center
        //Center
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
        #endregion

    }
}