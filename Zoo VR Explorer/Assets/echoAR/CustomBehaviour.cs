/**************************************************************************
* Copyright (C) echoAR, Inc. 2018-2020.                                   *
* echoAR, Inc. proprietary and confidential.                              *
*                                                                         *
* Use subject to the terms of the Terms of Service available at           *
* https://www.echoar.xyz/terms, or another agreement                      *
* between echoAR, Inc. and you, your company or other organization.       *
***************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.SceneManagement;

public class CustomBehaviour : MonoBehaviour
{
    [HideInInspector]
    public Entry entry;

    /// <summary>
    /// EXAMPLE BEHAVIOUR
    /// Queries the database and names the object based on the result.
    /// </summary>

    private bool handled;

    private string sceneName;

    // Use this for initialization
    void Start()
    {
        // Add RemoteTransformations script to object and set its entry
        this.gameObject.AddComponent<RemoteTransformations>().entry = entry;

        // Qurey additional data to get the name
        string value = "";
        if (entry.getAdditionalData() != null && entry.getAdditionalData().TryGetValue("name", out value))
        {
            // Set name
            this.gameObject.name = value;
        }

        handled = false;
    }

    // Update is called once per frame
    void Update()
    {
        string ObjectName = this.gameObject.name;
        sceneName = SceneManager.GetActiveScene().name;

        switch (ObjectName)
        {
            case "banana.glb":
                BananaBehav();
                break;
            case "Poplar_Tree.glb":
                PoplarTreeBehav();
                break;
            case "Palm_Tree.glb":
                PalmTreeBehav();
                break;
            case "LargeBrownFence.glb":
                LargeBrownFenceBehav();
                break;
            case "GreenFence.glb":
                GreenFenceBehav();
                break;
            case "Sign.glb":
                SignBehav();
                break;
            case "BrownFence.glb":
                BrownFenceBehav();
                break;
            case "AnimalFence.glb":
                AnimalFenceBehav();
                break;
            case "Tiger.glb":
                TigerBehav();
                break;
            case "Carrot.glb":
                VegetableBehav();
                break;
            case "monkey.glb":
                MonkeyBehav();
                break;
            case "Scarlet macaw.glb":
                MacawBehav();
                break;
            case "Macaw.glb":
                MacawBehav();
                break;
            case "Butterfly.glb":
                ButterflyBehav();
                break;
            case "Ground sloth.glb":
                SlothBehav();
                break;
            case "ColorfulTree.glb":
                ColorTreeBehav();
                break;
            case "Flower.glb":
                FlowerBehav();
                break;
            default:
                break;
        }

    }

    private void BananaBehav()
    {

        if (sceneName != "Monkey")
        {
            this.gameObject.SetActive(false);
        }
        RemoteTransformations remoteTrans = this.GetComponent<RemoteTransformations>();

        MeshRenderer meshRenderer = this.GetComponentInChildren<MeshRenderer>();

        //for those only applied at initialization
        if (!handled && meshRenderer != null)
        {
            GameObject meshObject = meshRenderer.gameObject;   //the actual object want actions to applied on
            remoteTrans.EchoSpin = false;

            meshObject.AddComponent<Rigidbody>();
            meshObject.AddComponent<MeshCollider>();

            meshObject.AddComponent<XRGrabInteractable>();
            meshObject.AddComponent<Banana>();

            handled = true;
        }

        remoteTrans.EchoPos = false;
        remoteTrans.EchoRot = false;
    }

    private void PoplarTreeBehav()
    {
        GameObject entranceArea = GameObject.Find("EntranceArea/Trees");
        if (this.gameObject.transform.childCount <= 0)
        {
            return;
        }

        entranceArea.GetComponent<EntranceAreaTrees>().tree = this.gameObject.transform.GetChild(0).GetChild(0).GetChild(0).gameObject;
        entranceArea.GetComponent<EntranceAreaTrees>().enabled = true;

        RemoteTransformations remoteTrans = this.GetComponent<RemoteTransformations>();

        MeshRenderer meshRenderer = this.GetComponentInChildren<MeshRenderer>();

        if (!handled && meshRenderer != null)
        {
            GameObject meshObject = meshRenderer.gameObject;   //the actual object want actions to applied on
            remoteTrans.EchoSpin = false;

            handled = true;
        }

        remoteTrans.EchoPos = false;
        remoteTrans.EchoRot = false;

        this.gameObject.SetActive(false);
    }

    private void PalmTreeBehav()
    {
        GameObject entranceArea = GameObject.Find("EntranceArea/PalmTrees");
        if (this.gameObject.transform.childCount <= 0)
        {
            return;
        }

        entranceArea.GetComponent<EntranceAreaPalmTrees>().tree = this.gameObject.transform.GetChild(0).GetChild(0).GetChild(0).gameObject;
        entranceArea.GetComponent<EntranceAreaPalmTrees>().enabled = true;

        RemoteTransformations remoteTrans = this.GetComponent<RemoteTransformations>();

        MeshRenderer meshRenderer = this.GetComponentInChildren<MeshRenderer>();

        if (!handled && meshRenderer != null)
        {
            GameObject meshObject = meshRenderer.gameObject;   //the actual object want actions to applied on
            remoteTrans.EchoSpin = false;

            handled = true;
        }

        remoteTrans.EchoPos = false;
        remoteTrans.EchoRot = false;

        this.gameObject.SetActive(false);
    }

    private void LargeBrownFenceBehav()
    {
        GameObject brownFenceSpawner = GameObject.Find("EntranceArea/BrownFences");
        if (this.gameObject.transform.childCount <= 0)
        {
            return;
        }
        brownFenceSpawner.GetComponent<EntranceAreaBrownFences>().fence = this.gameObject.transform.GetChild(0).GetChild(0).GetChild(0).gameObject;
        brownFenceSpawner.GetComponent<EntranceAreaBrownFences>().enabled = true;

        RemoteTransformations remoteTrans = this.GetComponent<RemoteTransformations>();

        MeshRenderer meshRenderer = this.GetComponentInChildren<MeshRenderer>();

        if (!handled && meshRenderer != null)
        {
            GameObject meshObject = meshRenderer.gameObject;   //the actual object want actions to applied on
            remoteTrans.EchoSpin = false;

            handled = true;
        }

        remoteTrans.EchoPos = false;
        remoteTrans.EchoRot = false;

        this.gameObject.SetActive(false);
    }

    private void GreenFenceBehav()
    {
        GameObject greenFenceSpawner = GameObject.Find("EntranceArea/Fences");
        if (this.gameObject.transform.childCount <= 0)
        {
            return;
        }

        greenFenceSpawner.GetComponent<GreenFences>().fence = this.gameObject.transform.GetChild(0).GetChild(0).GetChild(0).gameObject;
        greenFenceSpawner.GetComponent<GreenFences>().enabled = true;

        RemoteTransformations remoteTrans = this.GetComponent<RemoteTransformations>();

        MeshRenderer meshRenderer = this.GetComponentInChildren<MeshRenderer>();

        if (!handled && meshRenderer != null)
        {
            GameObject meshObject = meshRenderer.gameObject;   //the actual object want actions to applied on
            remoteTrans.EchoSpin = false;

            handled = true;
        }

        remoteTrans.EchoPos = false;
        remoteTrans.EchoRot = false;

        this.gameObject.SetActive(false);
    }

    private void SignBehav()
    {
        GameObject signSpawner = GameObject.Find("Signs");
        if (this.gameObject.transform.childCount <= 0)
        {
            return;
        }

        signSpawner.GetComponent<SignSpawner>().sign = this.gameObject.transform.GetChild(0).GetChild(0).gameObject;
        signSpawner.GetComponent<SignSpawner>().enabled = true;

        RemoteTransformations remoteTrans = this.GetComponent<RemoteTransformations>();

        MeshRenderer meshRenderer = this.GetComponentInChildren<MeshRenderer>();

        if (!handled && meshRenderer != null)
        {
            GameObject meshObject = meshRenderer.gameObject;   //the actual object want actions to applied on
            remoteTrans.EchoSpin = false;

            handled = true;
        }

        remoteTrans.EchoPos = false;
        remoteTrans.EchoRot = false;

        this.gameObject.SetActive(false);
    }

    private void BrownFenceBehav()
    {
        GameObject fenceSpawner = GameObject.Find("Fences");
        if (this.gameObject.transform.childCount <= 0)
        {
            return;
        }

        fenceSpawner.GetComponent<FenceSpawner>().fence = this.gameObject.transform.GetChild(0).GetChild(0).GetChild(0).gameObject;
        fenceSpawner.GetComponent<FenceSpawner>().enabled = true;

        GameObject fenceSpawner2 = GameObject.Find("Fences2");
        fenceSpawner2.GetComponent<FenceSpawner>().fence = this.gameObject.transform.GetChild(0).GetChild(0).GetChild(0).gameObject;
        fenceSpawner2.GetComponent<FenceSpawner>().enabled = true;

        RemoteTransformations remoteTrans = this.GetComponent<RemoteTransformations>();

        MeshRenderer meshRenderer = this.GetComponentInChildren<MeshRenderer>();

        if (!handled && meshRenderer != null)
        {
            GameObject meshObject = meshRenderer.gameObject;   //the actual object want actions to applied on
            remoteTrans.EchoSpin = false;

            handled = true;
        }

        remoteTrans.EchoPos = false;
        remoteTrans.EchoRot = false;

        this.gameObject.SetActive(false);
    }

    private void AnimalFenceBehav()
    {
        GameObject fenceSpawner = GameObject.Find("AnimalFences");
        if (this.gameObject.transform.childCount <= 0)
        {
            return;
        }

        fenceSpawner.GetComponent<AnimalFenceSpawner>().fence = this.gameObject.transform.GetChild(0).GetChild(0).GetChild(0).gameObject;
        fenceSpawner.GetComponent<AnimalFenceSpawner>().enabled = true;

        RemoteTransformations remoteTrans = this.GetComponent<RemoteTransformations>();

        MeshRenderer meshRenderer = this.GetComponentInChildren<MeshRenderer>();

        if (!handled && meshRenderer != null)
        {
            GameObject meshObject = meshRenderer.gameObject;   //the actual object want actions to applied on
            remoteTrans.EchoSpin = false;

            handled = true;
        }

        remoteTrans.EchoPos = false;
        remoteTrans.EchoRot = false;

        this.gameObject.SetActive(false);
    }
    private void TigerBehav()
    {
        GameObject tigerObject = GameObject.Find("Tiger");
        transform.parent = tigerObject.transform;
        transform.localPosition = new Vector3(0f, -0.25f, 0f);
        transform.localRotation = Quaternion.identity;
        transform.localEulerAngles = new Vector3(0f, 180f, 0f);
        transform.localScale = new Vector3(0.0045f, 0.0045f, 0.0045f);

        RemoteTransformations remoteTrans = this.GetComponent<RemoteTransformations>();

        MeshRenderer meshRenderer = this.GetComponentInChildren<MeshRenderer>();

        if (!handled && meshRenderer != null)
        {
            GameObject meshObject = meshRenderer.gameObject;   //the actual object want actions to applied on
            remoteTrans.EchoSpin = false;

            handled = true;
        }

        remoteTrans.EchoPos = false;
        remoteTrans.EchoRot = false;
        remoteTrans.EchoScale = false;
    }

    private void VegetableBehav()
    {
        GameObject vegetableSpawner = GameObject.Find("PointSpawners");
        if (this.gameObject.transform.childCount <= 0)
        {
            return;
        }

        vegetableSpawner.GetComponent<TigerPointSystem>().pointer = this.gameObject.transform.GetChild(0).GetChild(0).gameObject;
        vegetableSpawner.GetComponent<TigerPointSystem>().enabled = true;

        RemoteTransformations remoteTrans = this.GetComponent<RemoteTransformations>();

        MeshRenderer meshRenderer = this.GetComponentInChildren<MeshRenderer>();

        if (!handled && meshRenderer != null)
        {
            GameObject meshObject = meshRenderer.gameObject;   //the actual object want actions to applied on
            remoteTrans.EchoSpin = false;

            handled = true;
        }

        remoteTrans.EchoPos = false;
        remoteTrans.EchoRot = false;

        this.gameObject.SetActive(false);
    }

    private void MonkeyBehav()
    {
        if (sceneName == "Zoo_Map")
        {
            GameObject monkeyObj = GameObject.Find("Monkey");
            transform.parent = monkeyObj.transform;
            transform.localPosition = new Vector3(0f, -0.25f, 0f);
            transform.localRotation = Quaternion.identity;
            transform.localEulerAngles = new Vector3(0f, 180f, 0f);
            transform.localScale = new Vector3(0.0045f, 0.0045f, 0.0045f);
        }
        else if (sceneName != "Monkey")
        {
            this.gameObject.SetActive(false);
        }
        RemoteTransformations remoteTrans = this.GetComponent<RemoteTransformations>();

        MeshRenderer meshRenderer = this.GetComponentInChildren<MeshRenderer>();

        //for those only applied at initialization
        if (!handled && meshRenderer != null)
        {
            GameObject meshObject = meshRenderer.gameObject;   //the actual object want actions to applied on
            remoteTrans.EchoSpin = false;

            meshObject.AddComponent<MeshCollider>().convex = true;
            meshObject.AddComponent<Monkey>();

            handled = true;
        }

        remoteTrans.EchoPos = false;
        remoteTrans.EchoRot = false;
    }

    private void MacawBehav()
    {
        if (sceneName == "Zoo_Map")
        {
            GameObject macawObj = GameObject.Find("Macaw");
            transform.parent = macawObj.transform;
            transform.localPosition = new Vector3(0f, -0.25f, 0f);
            transform.localRotation = Quaternion.identity;
            transform.localEulerAngles = new Vector3(0f, 180f, 0f);
            transform.localScale = new Vector3(0.0045f, 0.0045f, 0.0045f);
        }

        RemoteTransformations remoteTrans = this.GetComponent<RemoteTransformations>();

        MeshRenderer meshRenderer = this.GetComponentInChildren<MeshRenderer>();

        //for those only applied at initialization
        if (!handled && meshRenderer != null)
        {
            GameObject meshObject = meshRenderer.gameObject;   //the actual object want actions to applied on
            remoteTrans.EchoSpin = false;
            remoteTrans.EchoPos = false;
            remoteTrans.EchoRot = false;

            meshObject.AddComponent<MeshCollider>().convex = true;
            meshObject.AddComponent<Macaw>();

            handled = true;
        }
    }

    private void ButterflyBehav()
    {
        if (sceneName == "Zoo_Map")
        {
            GameObject butterflyObj = GameObject.Find("Butterfly");
            transform.parent = butterflyObj.transform;
            transform.localPosition = new Vector3(0f, -0.25f, 0f);
            transform.localRotation = Quaternion.identity;
            transform.localEulerAngles = new Vector3(0f, 180f, 0f);
            transform.localScale = new Vector3(0.0045f, 0.0045f, 0.0045f);
            handled = true;
            return;
        }
        //for now havent' uploaded object to echoar yet.
        else if (sceneName != "Butterfly")
        {
            this.gameObject.SetActive(false);
        }

        RemoteTransformations remoteTrans = this.GetComponent<RemoteTransformations>();

        MeshRenderer meshRenderer = this.GetComponentInChildren<MeshRenderer>();

        //for those only applied at initialization
        if (!handled && meshRenderer != null)
        {
            GameObject meshObject = meshRenderer.gameObject;   //the actual object want actions to applied on
            remoteTrans.EchoSpin = false;

            meshObject.AddComponent<Rigidbody>();
            meshObject.AddComponent<MeshCollider>();

            meshObject.AddComponent<XRGrabInteractable>();
            meshObject.AddComponent<Butterfly>();

            handled = true;
        }

        remoteTrans.EchoPos = false;
        remoteTrans.EchoRot = false;

    }

    private void SlothBehav()
    {
        //for now havent' uploaded object to echoar yet.
        if (sceneName == "Zoo_Map")
        {
            GameObject slothObj = GameObject.Find("Sloth");
            transform.parent = slothObj.transform;
            transform.localPosition = new Vector3(0f, -0.25f, 0f);
            transform.localRotation = Quaternion.identity;
            transform.localEulerAngles = new Vector3(0f, 180f, 0f);
            transform.localScale = new Vector3(0.0045f, 0.0045f, 0.0045f);
        }
        else if (sceneName != "Sloth")
        {
            this.gameObject.SetActive(false);
        }
        else{
            transform.localEulerAngles = new Vector3(0f, -90f, 0f);
        }

        RemoteTransformations remoteTrans = this.GetComponent<RemoteTransformations>();

        MeshRenderer meshRenderer = this.GetComponentInChildren<MeshRenderer>();

        //for those only applied at initialization
        if (!handled && meshRenderer != null)
        {
            GameObject meshObject = meshRenderer.gameObject;   //the actual object want actions to applied on
            remoteTrans.EchoSpin = false;

            meshObject.AddComponent<Rigidbody>();
            meshObject.AddComponent<MeshCollider>();
            meshObject.AddComponent<MeshCollider>().convex = true;
            meshObject.AddComponent<Sloth>();

            handled = true;
        }

        remoteTrans.EchoPos = false;
        remoteTrans.EchoRot = false;

    }

    private void ColorTreeBehav()
    {
        GameObject colorTreeSpawner = GameObject.Find("EntranceArea/ColorTrees");
        if (this.gameObject.transform.childCount <= 0)
        {
            return;
        }

        colorTreeSpawner.GetComponent<EntranceAreaColorTrees>().tree = this.gameObject.transform.GetChild(0).GetChild(0).GetChild(0).gameObject;
        colorTreeSpawner.GetComponent<EntranceAreaColorTrees>().enabled = true;

        RemoteTransformations remoteTrans = this.GetComponent<RemoteTransformations>();

        MeshRenderer meshRenderer = this.GetComponentInChildren<MeshRenderer>();

        if (!handled && meshRenderer != null)
        {
            GameObject meshObject = meshRenderer.gameObject;   //the actual object want actions to applied on
            remoteTrans.EchoSpin = false;

            handled = true;
        }

        remoteTrans.EchoPos = false;
        remoteTrans.EchoRot = false;

        this.gameObject.SetActive(false);
    }



    private void FlowerBehav()
    {

        //if (sceneName != "Sloth")
        //{
        this.gameObject.SetActive(false);
        //}
        RemoteTransformations remoteTrans = this.GetComponent<RemoteTransformations>();

        MeshRenderer meshRenderer = this.GetComponentInChildren<MeshRenderer>();

        //for those only applied at initialization
        if (!handled && meshRenderer != null)
        {
            GameObject meshObject = meshRenderer.gameObject;   //the actual object want actions to applied on
            remoteTrans.EchoSpin = false;

            meshObject.AddComponent<Rigidbody>();
            meshObject.AddComponent<MeshCollider>();

            meshObject.AddComponent<XRGrabInteractable>();
            meshObject.AddComponent<Mountain>();

            handled = true;
        }

        remoteTrans.EchoPos = false;
        remoteTrans.EchoRot = false;
    }

    T CopyComponent<T>(T original, GameObject destination) where T : Component
    {
        System.Type type = original.GetType();
        var dst = destination.GetComponent(type) as T;
        if (!dst) dst = destination.AddComponent(type) as T;
        var fields = type.GetFields();
        foreach (var field in fields)
        {
            if (field.IsStatic) continue;
            field.SetValue(dst, field.GetValue(original));
        }
        var props = type.GetProperties();
        foreach (var prop in props)
        {
            if (!prop.CanWrite || !prop.CanWrite || prop.Name == "name") continue;
            prop.SetValue(dst, prop.GetValue(original, null), null);
        }
        return dst as T;
    }
}