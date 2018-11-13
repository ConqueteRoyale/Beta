using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// Network Manager fait à la main afin de créer une interface Utilisateur
public class NetworkManager_Custom : NetworkManager {

    // Assigne le port a un utilisateur
	public void StartupHost(){
        SetPort();
        NetworkManager.singleton.StartHost();
    }

    // Permet de rejoindre une partie en tant que client
    public void JoinGame(){
        SetIpAddress();
        SetPort();
        NetworkManager.singleton.StartClient();
    }

    // Assign une adress IP (pour l'instant j'ai mit localhost pour faciliter la tache
    public void SetIpAddress(){
        string ipAddress = "localhost";
        NetworkManager.singleton.networkAddress = ipAddress;
    }

    // Assigne le port au joueur, verifie les informations de l'hôte
    void SetPort(){
        NetworkManager.singleton.networkPort = 7777;
    }


    // Affichage des boutons du menu
    public void OnEnable(){
        SceneManager.sceneLoaded += OnLevelFinishedLoading;
    }

    void OnDisable(){
        //Tell our 'OnLevelFinishedLoading' function to stop listening for a scene change as soon as this script is disabled. Remember to always have an unsubscription for every delegate you subscribe to!
        SceneManager.sceneLoaded -= OnLevelFinishedLoading;
    }

    void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "Scene_EnJeu_ulysse"){
            SetUpMenuSceneButtons();
        } else{
            SetUpOtherSceneButtons();
        }
    }

    // Ajout des evenements onClick des boutons et appel des fonctions qui permettent de commencer ou rejoindre une partie
    public void SetUpMenuSceneButtons(){
        GameObject.Find("BtnCreate").GetComponent<Button>().onClick.RemoveAllListeners();
        GameObject.Find("BtnCreate").GetComponent<Button>().onClick.AddListener(StartupHost);

        GameObject.Find("BtnEntreAmis").GetComponent<Button>().onClick.RemoveAllListeners();
        GameObject.Find("BtnEntreAmis").GetComponent<Button>().onClick.AddListener(JoinGame);
    }

    // Ajout des evenements onClick des boutons et appel des fonctions
        // Permet de se déconnecter de la partie
    public void SetUpOtherSceneButtons(){
        Debug.Log("Deconecrtet toi tbk");
        GameObject.Find("Deconnexion").GetComponent<Button>().onClick.RemoveAllListeners();
        GameObject.Find("Deconnexion").GetComponent<Button>().onClick.AddListener(NetworkManager.singleton.StopHost);
    }

    public void QuitterleJeu(){
        Application.Quit();
    }

}
