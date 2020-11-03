using System;
using OpenTK;
using OpenTK.Graphics.ES11;
using OpenTK.Platform.Android;

using Android.Content;

namespace OpenGLTest
{
    class GLRenderer : AndroidGameView
    {
        float[] square_vertices = {
            -0.5f, -0.5f,
             0.5f, -0.5f,
            -0.5f,  0.5f,
        };

        byte[] square_colors = {
            255,   0,   0, 255, // red
            0,   255,   0, 255, // green
            0,     0, 255, 255, // blue
        };

        public GLRenderer(Context context) : base(context) {
            AutoSetContextOnRenderFrame = false;
            RenderOnUIThread = false;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Run();
        }

        protected override void CreateFrameBuffer()
        {
            try {
                base.CreateFrameBuffer();
                return;
            }
            catch (Exception ex) {}

            try {
                GraphicsMode = new AndroidGraphicsMode(0, 0, 0, 0, 0, false);
                base.CreateFrameBuffer();
                return;
            }
            catch (Exception ex) {}
        }
        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);

            // 'All' comes from OpenTK.Graphics.ES11
            GL.MatrixMode(All.Projection);
            GL.LoadIdentity();

            GL.Ortho(-Width/Height, Width/Height, -1f, 1f, -1f, 1f);

            GL.MatrixMode(All.Modelview);
            GL.ClearColor(0, 0, 0, 1);
            GL.Clear(ClearBufferMask.ColorBufferBit);

            GL.VertexPointer(2, All.Float, 0, square_vertices);
            GL.EnableClientState(All.VertexArray);
            GL.ColorPointer(4, All.UnsignedByte, 0, square_colors);
            GL.EnableClientState(All.ColorArray);

            GL.DrawArrays(All.Triangles, 0, 3);
            SwapBuffers();
        }
    }
}
