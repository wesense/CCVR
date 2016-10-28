using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class picturesScene : MonoBehaviour {

	public MeshRenderer[] fotos;
	public int fotoAtual;
	public GameObject webCam;

	void Start () {
		//configuracoes de qualidade
		QualitySettings.vSyncCount = 0;
		Application.targetFrameRate = 30;
		//setando as variaveis para inicio da experiencia
		fotoAtual = 0;

		/*
		Adiciona o metodo verificaFinal() ao evento OnTrigger, ou seja
		sempre que o trigger do cardboard for acionado ele vai executar este metodo
		Novos metodos podem ser adicionados, sendo assim o evento trigger 
		pode disparar diversos metodos
		*/
		GvrViewer.Instance.OnTrigger += verificaFinal;
	}

	public void verificaFinal(){
		if (fotoAtual > 2) {
			reiniciar ();
		}else if (fotoAtual == 2){
			tirarFoto ();
			verFotos ();
		} else {
			tirarFoto ();
		}
	}

	private void tirarFoto(){

		//recupera o componente(script) webcamtex do objeto preview da camera
		WebCamTexture cam = webCam.GetComponent<webcamtex> ().camTex;

		//Cria uma nova textura com as dimensoes do preview da camera
		Texture2D photoShot = new Texture2D(cam.width, cam.height);
		//seta os pixels desta nova textura, com os valores dos pixels do preview da camera
		photoShot.SetPixels32(cam.GetPixels32());
		//Aplica a alteracao feita acima na textura
		photoShot.Apply();

		//Adiciona a textura no objeto foto, com o id da foto atual
		fotos [fotoAtual].material.mainTexture = photoShot;
		//Atualiza a foto atual
		fotoAtual++;
	}

	private void reiniciar(){
		//reativa o preview da camera
		webCam.SetActive (true);
		//limpa a textura de todas as fotos
		foreach (MeshRenderer m in fotos) {
			m.material.mainTexture = null;
		}
		//zera a variavel para o inicio da experiencia
		fotoAtual = 0;
	}

	private void verFotos(){
		//Desativa o painel que mostra o preview da camera para as fotos ficarem visiveis
		webCam.SetActive (false);
	}

}
