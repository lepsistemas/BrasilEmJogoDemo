using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialog {

    private string speaker;

    public string Speaker {
        get {
            return this.speaker;
        }
        set {
            this.speaker = value;
        }
    }

    private string sentence;


    public string Sentence {
        get {
            return this.sentence;
        }
        set {
            this.sentence = value;
        }
    }

    public Dialog(string speaker, string sentence) {
        this.speaker = speaker;
        this.sentence = sentence;
    }

    public Dialog(string sentence) {
        this.sentence = sentence;
    }
    
}
