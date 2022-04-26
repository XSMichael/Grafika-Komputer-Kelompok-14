using LearnOpenTK.Common;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Windowing.GraphicsLibraryFramework;
using OpenTK.Mathematics;


namespace Digimon
{
    
    static class Constants
    {
        public const string path = "../../../Shaders/";

    }
    internal class Window : GameWindow
    {
        List<MyObject> _object = new List<MyObject>();
        Camera _camera;
        bool _firstMove = true;
        Vector2 _lastPos;
        Vector3 _objectPos = new Vector3(0, 0, 0);
        float _rotationSpeed = 1f;

        double _time = 0;
        double rotate_speed = 100;
        bool isRotate = false; //rotate seluruh object di 1 pusat
        int typeTransform = 1; //untuk rotate dan translate per object

        public Window(GameWindowSettings gameWindowSettings, NativeWindowSettings nativeWindowSettings) : base(gameWindowSettings, nativeWindowSettings)
        {
        }

        protected override void OnLoad()
        {
            base.OnLoad();
            GL.ClearColor(51/255f, 231 / 255f, 255 / 255f, 1.0f);
            GL.Enable(EnableCap.DepthTest);
            GL.Enable(EnableCap.Blend);


            _object = new List<MyObject>();
            _time = 0;
            rotate_speed = 100;
            isRotate = false;
            typeTransform = 1;

            Viximon viximon = new Viximon();
            _object.Add(viximon);

            Budmon budMonObj = new Budmon();
            _object.Add(budMonObj);
            
            Kapurimon kapurimon = new Kapurimon();
            _object.Add(kapurimon);

            House house = new House();
            _object.Add(house);

            Ground ground = new Ground();
            _object.Add(ground);

            Sky sky = new Sky();
            _object.Add(sky);
            Atmosphere atmosphere = new Atmosphere();
            _object.Add(atmosphere);

            

            for (int i = 0; i < _object.Count(); i++)
            {
                _object[i].load(Constants.path + "Shader.vert", Constants.path + "shader.frag", Size.X, Size.Y);
            }

            #region Camera
            _camera = new Camera(new Vector3(0, 0, 2.5f), Size.X / Size.Y);
            #endregion

            CursorGrabbed = true;
        }

        protected override void OnRenderFrame(FrameEventArgs args)
        {
            base.OnRenderFrame(args);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            GL.BlendFunc(BlendingFactor.SrcAlpha, BlendingFactor.OneMinusSrcAlpha);
            _time = rotate_speed * args.Time;


            _object[0].render(args, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            _object[1].render(args, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            _object[2].render(args, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            _object[3].render(args, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            _object[4].render(args, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            _object[5].render(args, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            _object[6].render(args, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());

            SwapBuffers();
        }

        protected override void OnResize(ResizeEventArgs e)
        {
            base.OnResize(e);
            GL.Viewport(0, 0, Size.X, Size.Y);
            _camera.AspectRatio = Size.X / (float)Size.Y;
        }

        protected override void OnUpdateFrame(FrameEventArgs args)
        {
            base.OnUpdateFrame(args);
            //biasa untuk mengecek apakah ada terima inputan dri keyboard atau tidak

            if (!IsFocused)
            {
                return; //Reject semua input saat window bukan focus.
            }

            var input = KeyboardState;
            if (input.IsKeyDown(Keys.Escape))//waktu tombol sedang ditekan
            {
                Close();
            }
            
            #region camera
            float cameraSpeed = 0.5f;
            if (input.IsKeyDown(Keys.W))
            {
                _camera.Position += _camera.Front * cameraSpeed * (float)args.Time;
            }
            if (input.IsKeyDown(Keys.S))
            {
                _camera.Position -= _camera.Front * cameraSpeed * (float)args.Time;
            }
            if (input.IsKeyDown(Keys.A))
            {
                _camera.Position -= _camera.Right * cameraSpeed * (float)args.Time;
            }
            if (input.IsKeyDown(Keys.D))
            {
                _camera.Position += _camera.Right * cameraSpeed * (float)args.Time;
            }
            if (input.IsKeyDown(Keys.Space))
            {
                _camera.Position += _camera.Up * cameraSpeed * (float)args.Time;
            }
            if (input.IsKeyDown(Keys.LeftShift))
            {
                _camera.Position -= _camera.Up * cameraSpeed * (float)args.Time;
            }

            var mouse = MouseState;
            var sensitivity = 0.1f;

            if (_firstMove)
            {
                _lastPos = new Vector2(mouse.X, mouse.Y);
                _firstMove = false;
            }
            else
            {
                var deltaX = mouse.X - _lastPos.X;
                var deltaY = mouse.Y - _lastPos.Y;
                _lastPos = new Vector2(mouse.X, mouse.Y);
                _camera.Yaw += deltaX * sensitivity; //rotate kiri kanan
                _camera.Pitch -= deltaY * sensitivity; //rotate atas bawah //ada batasan jauh rotate
            }

            #endregion

            //reset button
            if (input.IsKeyPressed(Keys.RightShift))
            {
                this.OnLoad();
            }

            // on/off idle1
            if (input.IsKeyPressed(Keys.RightControl))
            {
                bool temp = !_object[0].isIdle1();
                foreach(var obj in _object)
                {
                    obj.isIdle1(temp);
                }
            }
            // on/off all idle
            if (input.IsKeyPressed(Keys.RightAlt))
            {
                bool temp = !_object[0].isIdle2();
                foreach (var obj in _object)
                {
                    obj.isIdle1(temp);
                    obj.isIdle2(temp);
                }
            }

            #region transformasi
            //enable/disable object for using rotate, translation
            if (input.IsKeyPressed(Keys.D1))
            {
                _object[0].changeStatus();
                isRotate = false;
            }
            else if (input.IsKeyReleased(Keys.D2))
            {
                _object[1].changeStatus();
                isRotate = false;
            }
            else if (input.IsKeyReleased(Keys.D3))
            {
                _object[2].changeStatus();
                isRotate = false;
            }

            //Mengaktifkan salah satu dari rotate, translation
            if (input.IsKeyPressed(Keys.LeftControl))
            {
                isRotate = !isRotate;
                if (isRotate)
                {
                    foreach(var obj in _object)
                    {
                        obj.setStatus(false);
                    }
                }
                //isRotate dan isTranslate selalu berlawanan
            }else if (input.IsKeyPressed(Keys.LeftAlt))
            {
                isRotate = false;
                if(typeTransform == 0)
                {
                    typeTransform = 1;
                }else if(typeTransform == 1)
                {
                    typeTransform = 0;
                }
            }

            //*Rotate: left right sumbu y
            //*Translation: up down sumbu z, left right x
            //*Rotate keseluruhan: left right sumbu y

            if (input.IsKeyDown(Keys.Up))
            {
                foreach(var obj in _object)
                {
                    if (obj.getStatus())
                    {
                        if (typeTransform == 0)
                        {
                            obj.Translation(0, 0, -0.008f);
                        }
                    }
                }
            }else if (input.IsKeyDown(Keys.Down))
            {
                foreach (var obj in _object)
                {
                    if (obj.getStatus())
                    {
                        if (typeTransform == 0)
                        {
                            obj.Translation(0, 0, 0.008f);
                        }
                    }
                }
            }
            else if (input.IsKeyDown(Keys.Right))
            {
                if (!isRotate)
                {
                    foreach (var obj in _object)
                    {
                        if (obj.getStatus())
                        {
                            if (typeTransform == 0)
                            {
                                obj.Translation(0.008f, 0, 0);
                            }
                            else if (typeTransform == 1)
                            {
                                obj.resetScale();
                                obj.Rotate(obj.getCenter(),1, _time);
                                obj.addRotateValue(new Vector3(0, (float)_time, 0));
                            }
                        }
                    }
                }
                else
                {
                    foreach(var obj in _object)
                    {
                        obj.resetScale();
                        obj.Rotate(new Vector3(0, 0, 0), 1, _time);
                    }
                }
                
            }
            else if (input.IsKeyDown(Keys.Left))
            {
                if (!isRotate)
                {
                    foreach (var obj in _object)
                    {
                        if (obj.getStatus())
                        {
                            if (typeTransform == 0)
                            {
                                obj.Translation(-0.008f, 0,0);
                            }
                            else if (typeTransform == 1)
                            {
                                obj.resetScale();
                                obj.Rotate(obj.getCenter(),1, -_time);
                                obj.addRotateValue(new Vector3(0, (float)-_time, 0));
                            }
                        }
                    }
                }
                else
                {
                    foreach (var obj in _object)
                    {
                        obj.resetScale();
                        obj.Rotate(new Vector3(0, 0, 0), 1, -_time);
                    }
                }
            }
            #endregion
        }

        protected override void OnMouseDown(MouseButtonEventArgs e)
        {
            base.OnMouseDown(e);
        }
        protected override void OnMouseWheel(MouseWheelEventArgs e)
        {
            base.OnMouseWheel(e);
            _camera.Fov = _camera.Fov - e.OffsetY;
        }

        public Matrix4 generateArbRotationMatrix(Vector3 axis, Vector3 center, float degree)
        {
            var rads = MathHelper.DegreesToRadians(degree);

            var secretFormula = new float[4, 4] {
                { (float)Math.Cos(rads) + (float)Math.Pow(axis.X, 2) * (1 - (float)Math.Cos(rads)), axis.X* axis.Y * (1 - (float)Math.Cos(rads)) - axis.Z * (float)Math.Sin(rads),    axis.X * axis.Z * (1 - (float)Math.Cos(rads)) + axis.Y * (float)Math.Sin(rads),   0 },
                { axis.Y * axis.X * (1 - (float)Math.Cos(rads)) + axis.Z * (float)Math.Sin(rads),   (float)Math.Cos(rads) + (float)Math.Pow(axis.Y, 2) * (1 - (float)Math.Cos(rads)), axis.Y * axis.Z * (1 - (float)Math.Cos(rads)) - axis.X * (float)Math.Sin(rads),   0 },
                { axis.Z * axis.X * (1 - (float)Math.Cos(rads)) - axis.Y * (float)Math.Sin(rads),   axis.Z * axis.Y * (1 - (float)Math.Cos(rads)) + axis.X * (float)Math.Sin(rads),   (float)Math.Cos(rads) + (float)Math.Pow(axis.Z, 2) * (1 - (float)Math.Cos(rads)), 0 },
                { 0, 0, 0, 1}
            };
            var secretFormulaMatix = new Matrix4
            (
                new Vector4(secretFormula[0, 0], secretFormula[0, 1], secretFormula[0, 2], secretFormula[0, 3]),
                new Vector4(secretFormula[1, 0], secretFormula[1, 1], secretFormula[1, 2], secretFormula[1, 3]),
                new Vector4(secretFormula[2, 0], secretFormula[2, 1], secretFormula[2, 2], secretFormula[2, 3]),
                new Vector4(secretFormula[3, 0], secretFormula[3, 1], secretFormula[3, 2], secretFormula[3, 3])
            );

            return secretFormulaMatix;
        }
    }
}
