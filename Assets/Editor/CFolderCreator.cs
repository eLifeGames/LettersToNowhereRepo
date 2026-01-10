using UnityEngine;
using UnityEditor;
using System.IO;
using UnityEditor.ProjectWindowCallback;

namespace Assets.Editor
{
    public static class CFolderCreator
    {
        [SerializeField]
        public static string RootPath = "_Root";

        [MenuItem("Assets/Create/CFolder", false, 2)]
        private static void CreateFolder()
        {
            string parentPath = GetSelectedPathOrFallback();

            ProjectWindowUtil.StartNameEditingIfProjectWindowExists(
                0,
                ScriptableObject.CreateInstance<CreateCFolderAction>(),
                Path.Combine(parentPath, "New CFolder"),
                EditorGUIUtility.IconContent("Folder Icon").image as Texture2D,
                null
            );
        }
        
        private static string GetSelectedPathOrFallback()
        {
            string path = Path.Combine(Application.dataPath, RootPath);

            if (Selection.activeObject != null)
            {
                path = AssetDatabase.GetAssetPath(Selection.activeObject);
                if (File.Exists(path))
                    path = Path.GetDirectoryName(path);
            }

            return path;
        }
    }

    internal class CreateCFolderAction : EndNameEditAction
    {
        public override void Action(int instanceId, string pathName, string resourceFile)
        {
            AssetDatabase.CreateFolder(
                Path.GetDirectoryName(pathName),
                Path.GetFileName(pathName)
            );

            AssetDatabase.CreateFolder(pathName, "Application");
            AssetDatabase.CreateFolder(pathName, "Domain");
            AssetDatabase.CreateFolder(pathName, "Infrastructure");

            AssetDatabase.Refresh();
            Selection.activeObject = AssetDatabase.LoadAssetAtPath<Object>(pathName);
        }
    }
}