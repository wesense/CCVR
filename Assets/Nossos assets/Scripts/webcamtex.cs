using UnityEngine;
using System.Collections;

public class webcamtex : MonoBehaviour {

	public WebCamTexture camTex;

	void Start () {

		//Lista todos as "webcams" disponiveis na plataforma
		WebCamDevice[] devices = WebCamTexture.devices;
		//Armazena o nome do primeiro componente camera encontrado
		string camName = devices [0].name;
		//Cria uma textura com a imagem da camera selecionada
		camTex = new WebCamTexture (camName);
		//Play na textura, para que ela atualize os frames da camera
		camTex.Play ();
		//Atribui a nova textura com a imagem da camera no objeto Plane que contem o script
		this.gameObject.GetComponent<MeshRenderer> ().material.mainTexture = camTex;
	
	}

}
