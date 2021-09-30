# Unity-Oculus-echo3D-demo-VR-Zoo-Explorer
A VR experience of a zoo with echo3D and Oculus Quest in Unity

## Register
Don't have an API key? Make sure to register for FREE at [echo3D](https://console.echo3D.co/#/auth/register).

## Setup
* Clone the [Unity-Oculus-echo3D-demo-VR-Zoo-Explorer](https://github.com/echo3Dco/Unity-Oculus-echo3D-demo-VR-Zoo-Explorer/).

### Echo API Setup
* [Set the API key](https://docs.echo3D.co/unity/using-the-sdk) in the `echoAR.cs` script inside the `echoAR\echoAR.prefab` using the the Inspector.
* [Add the 3D model](https://docs.echo3D.co/quickstart/add-a-3d-model) from the 'Models' folder to the console in corresponding scenes. 
* Each folder in the Models folder should be a new project (API key) in your echo3D console. So for example, there would be an API key holding all of the models from the Overworld Models folder, another API key holding all of the models from the Tiger Models folder, another API key holding all of the models from the Macaw Models folder, etc.
* If a model does not have a corresponding CSV file, it means that there is no metadata to input for that model. Hence, you can skip adding any metadata to that model. Otherwise, copy the metadata from each model's corresponding CSV file in the folder. 
* We recommend to add videos and audios from `Models\VideosAudios` to a seperate key [Load a Key](https://docs.echo3D.co/web-console/load-a-key).
* Set the Video API key inside the `Prefabs\echoAR (video).prefab` using the the Inspector.
* [Add the corresponding metadata](https://docs.echo3D.co/web-console/manage-pages/data-page/how-to-add-data#adding-metadata) listed in the `Models` folder.
* For videos and audios project, make sure all models' metadata have a "Index" key with a special non-negative integer value.

## Build & Run
* [Build and run the application](https://docs.echo3D.co/unity/adding-ar-capabilities#4-build-and-run-the-ar-application) in VR.

## Learn more
Refer to our [documentation](https://docs.echo3D.co/unity/) to learn more about how to use Unity and echo3D.

## Support
Feel free to reach out at [support@echo3D.co](mailto:support@echo3D.co) or join our [support channel on Slack](https://go.echo3D.co/join). 

## Screenshots
![Zoo Map screenshot](/Screenshots/ZooMap.png)
![Zoo Map dialogue screenshot](/Screenshots/Dialogue.png)
![Butterfly Scene screenshot](/Screenshots/butterfly.png)
![Macaw Scene screenshot](/Screenshots/macaw.png)
![Monkey Scene screenshot](/Screenshots/monkey.png)
![Sloth Scene screenshot](/Screenshots/sloth.png)
![Tiger Scene screenshot](/Screenshots/tiger.png)
![echo3D console screenshot for content](/Screenshots/model.png)
![echo3D console screenshot for metadata](/Screenshots/metadata.png)

## Resources and Reference
### XR Rig Setup
* [How To Make a VR Game in 2021 - New Input System and OpenXR Support by Valem](https://youtu.be/u6Rlr2021vw).
* [How to do Continuous Movement in Unity VR | OpenXR Locomotion Tutorial by Justin P Barnett - VR Game Dev](https://youtu.be/_Zrde_WTaiI).
* [Oculus Hands Model 1.0 - Licensed under the Creative Commons Attribution 4.0, Copyright 2017 Oculus VR, LLC. All rights reserved](https://developer.oculus.com/downloads/package/oculus-hand-models/).
* [XR Hands set-up: How to ANIMATE Hands in VR - Unity XR Beginner Tutorial (New Input System) by Justin P Barnett - VR Game Dev](https://youtu.be/DxKWq7z4Xao).
### Videos and Audios
* [Butterflies Flying in Slow Motion HD - Houston Butterfly Museum](https://youtu.be/aBfJtTm_XD4)
* [8 Most Beautiful Macaws on Planet Earth](https://youtu.be/OW7J_3z1MOI)
* [The Extreme Life Of A Sloth](https://youtu.be/DpV4k3Edr-I)
* [Absolutely Incredible! Tiger runs through water to catch prey! (From Tiger: Lord of The Wild)](https://youtu.be/YgYu-I7E3H4)
* [Wild Monkey eating banana , Cute Animals-MV 0034](https://youtu.be/8S9LLiBx91w)
* [Happy Monkey](https://freesound.org/people/samuelburt/sounds/133125/)
* [Tour Guide Text Nibbling Sound](https://www.youtube.com/watch?v=YekLRkiIW4Y)
* [Parrot](https://freesound.org/people/13FPanska_Machacova_Petra/sounds/377532/)
* [Tiger Growling](https://www.youtube.com/watch?v=5zpg6rDH0qA)
### Unity Assets
* [Forest prefab: LowPolyForest - Standard Unity Asset Store EULA](https://assetstore.unity.com/packages/3d/environments/lowpolyforest-53156)
* [Human prefab: Distant Lands Free Characters - Standard Unity Asset Store EULA](https://assetstore.unity.com/packages/3d/characters/distant-lands-free-characters-178123)
* [Fence prefab: Low Poly Fence Pack - Standard Unity Asset Store EULA](https://assetstore.unity.com/packages/3d/props/exterior/low-poly-fence-pack-61661)
* [Tree prefab: Free Trees - Standard Unity Asset Store EULA](https://assetstore.unity.com/packages/3d/vegetation/trees/free-trees-103208)

## Developers
* [Lujia Wang](https://lugawang.com/)
* [Philip Park](https://philippark0203.itch.io/)
* Jessica J Chen

