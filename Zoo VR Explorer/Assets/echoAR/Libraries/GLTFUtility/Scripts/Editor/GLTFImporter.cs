
using UnityEngine;

namespace Siccity.GLTFUtility {
	[UnityEditor.AssetImporters.ScriptedImporter(1, "gltf")]
	public class GLTFImporter : UnityEditor.AssetImporters.ScriptedImporter {

		public ImportSettings importSettings;

		public override void OnImportAsset(UnityEditor.AssetImporters.AssetImportContext ctx) {
			// Load asset
			GLTFAnimation.ImportResult[] animations;
			GameObject root = Importer.LoadFromFile(ctx.assetPath, importSettings, out animations, Format.GLTF);
			// Save asset
			GLTFAssetUtility.SaveToAsset(root, animations, ctx);
		}
	}
}