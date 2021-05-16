using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class LocalisationTexts : MonoBehaviour
{
	
	public static LocalisationTexts instance;

	
    private string[] keys = {"howmanual", "howblock", "howsome", "aboutdeveloper", "aboutgames", "aboutmore"
		};

    private string[] english = {"TAP TO ROTATE THEN CONNECT THE START TO THE END TO SOLVE THE PUZZLE", "BLOCKED WAY", "HIDDEN WAY", "Developer", "+ Games", "...and more..."
		};

    private string[] french = {"TAP POUR ROTATION PUIS CONNECTEZ LE DEBUT A LA FIN POUR RESOUDRE LE PUZZLE", "VOIE BLEUE", "VOIE CACHEE", "Developpeur", "+ Jeux", "...et plus..."
		};

    private string[] german = { "ZUM WENDEN BERÜHREN. VERBINDEN SIE DEN START UND ENDE UM DAS PUZZLE ZU VERVOLLSTANDIGEN", "SPERREN WEG", "VERSTECKTEN WEG", "Entwickler", "+ Spiele", "...und mehr..." 
		};

    private string[] italian = {"RUOTARE PER COLLEGARE L INIZIO ALLA FINE PER RISOLVERE IL PUZZLE", "MODO BLOCCATO", "MODO NASCOSTO", "Sviluppatore", "+ Giochi", "...e altro..." 
		};
		
    private string[] spanish = {"GIRE Y CONECTE EL COMIENZO HASTA EL FINAL PARA RESOLVER EL ROMPECABEZAS", "CAMINO BLOQUEADO", "CAMINO OCULTO", "Desarrollador", "+ Juegos", "...y mas..." 
		};

    private string[] portugese = {"TOQUE PARA RODAR ENTAO CONECTE O INÍCIO AO FINAL PARA RESOLVER O ENIGMA", "MODO BLOQUEADO", "MODO ESCONDIDO", "Desenvolvedor", "+ Jogos", "...e mais..."
		};

    private string[] texts;
    private Dictionary<string, string> mappedTexts = new Dictionary<string, string>();

    void Awake() {
		if (instance == null) {
			instance = this;
		}		
		
        SystemLanguage language = Application.systemLanguage;

        switch (language)
        {
            case SystemLanguage.French:
                texts = french;
                break;
            case SystemLanguage.German:
                texts = german;
                break;
            case SystemLanguage.Italian:
                texts = italian;
                break;
            case SystemLanguage.Spanish:
                texts = spanish;
                break;
            case SystemLanguage.Portuguese:
                texts = portugese;
                break;
            default:
                texts = english;
                break;
        }

        for (int i=0;i<keys.Length;i++) {
            mappedTexts.Add(keys[i], texts[i]);
        }
    }

    public string GetLocalisedText(string key) {
        return mappedTexts[key];
    }
}