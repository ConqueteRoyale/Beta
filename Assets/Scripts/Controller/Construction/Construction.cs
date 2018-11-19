// Script gérant la construction des bâtiments : leur placement sur la carte et ses conséquences
// Auteur principal: Lucas Theillet
// Autres auteurs : Nguyen Hoai Nguyen (isPlaceable - si les bâtiments peuvent être placés ou pas selon le terrain et les obstacles)


using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.Networking;

public class Construction : MonoBehaviour
{
    // Boutons de l'UI pour construire
    public Button btnConstruireMine;
    public Button btnConstruireMineGrande;
    public Button btnConstruireCaserneLancier;
    public Button btnConstruireCaserneChevalier;
    public Button btnConstruireCaserneArcher;

    // Les prefabs des différents bâtiments
    public GameObject minePrefab;
    public GameObject mineGrandePrefab;
    public GameObject caserneLancierPrefab;
    public GameObject caserneChevalierPrefab;
    public GameObject caserneArcherPrefab;

    // Les raccourcis-clavier pour construire des bâtiments
    private KeyCode newMine = KeyCode.Alpha1;
    private KeyCode newMineGrande = KeyCode.Alpha2;
    private KeyCode newCaserneLancier = KeyCode.Alpha3;
    private KeyCode newCaserneChevalier = KeyCode.Alpha4;
    private KeyCode newCaserneArcher = KeyCode.Alpha5;

    // Le bâtiment en train d'être placé
    private GameObject currentPlaceableObject;

    // Le son de construction lorsqu'on place un bâtiment
    public AudioClip clipSonConstruction;
    public AudioSource sonConstruction;

    // Bool indiquant si le bâtiment est constructible ou pas
    public bool isPlaceable;


    // Au début de la partie, on ajoute des détecteurs de clics au boutons de l'UI
    private void Start() {
        Button btn1 = btnConstruireMine.GetComponent<Button>();
        Button btn2 = btnConstruireMineGrande.GetComponent<Button>();
        Button btn3 = btnConstruireCaserneLancier.GetComponent<Button>();
        Button btn4 = btnConstruireCaserneChevalier.GetComponent<Button>();
        Button btn5 = btnConstruireCaserneArcher.GetComponent<Button>();

        btn1.onClick.AddListener(delegate {GestionNouveauBatimentBtn("mine"); });
        btn2.onClick.AddListener(delegate {GestionNouveauBatimentBtn("mineGrande"); });
        btn3.onClick.AddListener(delegate {GestionNouveauBatimentBtn("lancier"); });
        btn4.onClick.AddListener(delegate {GestionNouveauBatimentBtn("chevalier"); });
        btn5.onClick.AddListener(delegate {GestionNouveauBatimentBtn("archer"); });
    }


    // À chaque frame
    private void Update()
    {
        GestionNouveauBatimentKey(); // Detection d'un raccourci de construction

        // Si un bâtiment est en train d'être placé par le joueur (mode 'fantôme')
        if (currentPlaceableObject != null)
        {
            DeplacerObjetVersCurseur(); // On le déplace à la position du curseur
            ConstruireAuClic(); // On lance la fonction de construction
        }

        // Si le bâtiment est à un emplacement constructible, on affiche un contour vert
        if(isPlaceable == true)
        {
            currentPlaceableObject.GetComponent<Outline>().OutlineColor = Color.green;
        }

        // Si le bâtiment n'est pas à un emplacement constructible, on affiche un contour rouge
        if(isPlaceable == false)
        {
            currentPlaceableObject.GetComponent<Outline>().OutlineColor = Color.red;
        }
    }


    // AU CLIC SUR UN DES BOUTONS DE CONSTRUCTION, ON PLACE UN "FANTÔME" DU BÂTIMENT SUR LA SCÈNE
    private void GestionNouveauBatimentBtn(string type)
    {
        // Bâtiment MINE 
        if (type == "mine")
        {
            // Si l'object n'est plus en mode placement, on supprime son 'fantôme'
            if (currentPlaceableObject != null)
            {
                Destroy(currentPlaceableObject);
            }
            // Sinon on place un vrai bâtiment sur la carte depuis un prefab
            else
            {
                currentPlaceableObject = Instantiate(minePrefab);
            }
        }

        // Bâtiment GRANDE MINE 
        if (type == "mineGrande")
        {
            // Si l'object n'est plus en mode placement, on supprime son 'fantôme'
            if (currentPlaceableObject != null)
            {
                Destroy(currentPlaceableObject);
            }
            // Sinon on place un vrai bâtiment sur la carte depuis un prefab
            else
            {
                currentPlaceableObject = Instantiate(mineGrandePrefab);
            }
        }

        // Bâtiment LANCIER 
        if (type == "lancier")
        {
            if (currentPlaceableObject != null)
            {
                Destroy(currentPlaceableObject);
            }
            else
            {
                currentPlaceableObject = Instantiate(caserneLancierPrefab);
            }
        }

        // Bâtiment CHEVALIER 
        if (type == "chevalier")
        {
            if (currentPlaceableObject != null)
            {
                Destroy(currentPlaceableObject);
            }
            else
            {
                currentPlaceableObject = Instantiate(caserneChevalierPrefab);
            }
        }

        // Bâtiment ARCHER 
        if (type == "archer")
        {
            if (currentPlaceableObject != null)
            {
                Destroy(currentPlaceableObject);
            }
            else
            {
                currentPlaceableObject = Instantiate(caserneArcherPrefab);
            }
        }

    }    
    // AU CLIC OU TOUCHE-RACCOURCI, ON PLACE UN "FANTÔME" DU BÂTIMENT SUR LA SCÈNE
    // Même code que la fonction GestionNouveauBatimentBtn() mais utilise des keycode plutôt que des boutons
    private void GestionNouveauBatimentKey()
    {

        // MINE 
        if (Input.GetKeyDown(newMine))
        {
            if (currentPlaceableObject != null)
            {
                Destroy(currentPlaceableObject);
            }
            else
            {
                currentPlaceableObject = Instantiate(minePrefab);
            }
        }

        // GRANDE MINE 
        if (Input.GetKeyDown(newMineGrande))
        {
            if (currentPlaceableObject != null)
            {
                Destroy(currentPlaceableObject);
            }
            else
            {
                currentPlaceableObject = Instantiate(mineGrandePrefab);
            }
        }

        // CASERNE LANCIER 
        if (Input.GetKeyDown(newCaserneLancier))
        {
            if (currentPlaceableObject != null)
            {
                Destroy(currentPlaceableObject);
            }
            else
            {
                currentPlaceableObject = Instantiate(caserneLancierPrefab);
            }
        }

        
        // CASERNE CHEVALIER 
        if (Input.GetKeyDown(newCaserneChevalier))
        {
            if (currentPlaceableObject != null)
            {
                Destroy(currentPlaceableObject);
            }
            else
            {
                currentPlaceableObject = Instantiate(caserneChevalierPrefab);
            }
        }

        // CASERNE ARCHER 
        if (Input.GetKeyDown(newCaserneArcher))
        {
            if (currentPlaceableObject != null)
            {
                Destroy(currentPlaceableObject);
            }
            else
            {
                currentPlaceableObject = Instantiate(caserneArcherPrefab);
            }
        }          
    }


    // DÉPLACEMENT DU "FANTÔME" DU BÂTIMENT À LA POSITION DE LA SOURIS
    private void DeplacerObjetVersCurseur()
    {
        // Raycast depuis la caméra jusqu'à la position de la souris
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        // Lorsque le raycast touche, on déplace le fantôme de bâtiment jusqu'au curseur
        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo))
        {
            currentPlaceableObject.transform.position = hitInfo.point;
            isPlaceable = currentPlaceableObject.GetComponent<BuildPlaceable>().isBuildable; // et on indique s'il est constructible ou non
            //Debug.Log(isPlaceable);
          
        }
    }



    // DÉCLENCHEMENT DE LA CONSTRUCTION AU CLIC 
    private void ConstruireAuClic()
    {
        // Si on fait un clic gauche et que le bâtiment est dans une zone constructible, on le construit
        if (Input.GetMouseButtonDown(0) && isPlaceable == true)
        {
                StartCoroutine(GestionConstruction(currentPlaceableObject));
                currentPlaceableObject = null;
                
        }
    }



    // GESTION DE LA CONSTRUCTION DES BÂTIMENTS
    IEnumerator GestionConstruction(GameObject objet)
    {
        // On active différents éléments du gameobject
        objet.GetComponent<Collider>().enabled = true;
        objet.gameObject.GetComponent<Outline>().enabled = false;
        // La construction du bâtiment est COMMENCÉE
        GameObject particuleConstru = objet.gameObject.transform.GetChild(0).gameObject; // L'effet de particule de construction
        GameObject canvaConstru = objet.gameObject.transform.GetChild(1).gameObject; // La barre de progression de construction

        particuleConstru.SetActive(true); // Particules activées
        canvaConstru.SetActive(true); // Barre de construction activée
        sonConstruction.PlayOneShot(clipSonConstruction, 1f);

        // Durée de la construction en secondes
        yield return new WaitForSeconds(10f);

        // La construction du bâtiment est TERMINÉE
        // On désactive les particules et la barre de progrès
        particuleConstru.SetActive(false);
        canvaConstru.SetActive(false);
        objet.GetComponent<SpawnUnits>().enabled = true;
    }
}