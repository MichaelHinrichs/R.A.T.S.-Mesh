//Written for R.A.T.S. https://store.steampowered.com/app/553440/
using System.Collections.Generic;
using System.IO;
using System.Numerics;

namespace R.A.T.S_Mesh
{
    public class MESH
    {
        private string name;
        private readonly List<string> textures;
        private readonly List<Vector3> points;
        private readonly List<Vector3> normals;
        private readonly List<Vector2> uvs;
        private readonly List<Vector3> faces;

        private static MESH Read(string meshFile)
        {
            BinaryReader br = new(File.OpenRead(meshFile));
            MESH mesh = new()
            {
                name = new(br.ReadChars(br.ReadInt32()))
            };

            int textureCount = br.ReadInt32();
            for (int i = 0; i < textureCount; i++)
            {
                mesh.textures.Add(new(br.ReadChars(br.ReadInt32())));
            }

            int pointCount = br.ReadInt32();
            for (int i = 0; i < pointCount; i++)
            {
                mesh.points.Add(new Vector3(br.ReadInt32(), br.ReadInt32(), br.ReadInt32()));
                mesh.normals.Add(new Vector3(br.ReadInt32(), br.ReadInt32(), br.ReadInt32()));
                mesh.uvs.Add(new Vector2(br.ReadInt32(), br.ReadInt32()));
            }

            int faceCount = br.ReadInt32();
            for (int i = 0; i < faceCount; i++)
            {
                mesh.faces.Add(new Vector3(br.ReadInt32(), br.ReadInt32(), br.ReadInt32()));
            }
            return mesh;
        }
    }
}
