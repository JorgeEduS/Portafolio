package evidencia2;

public class NodoArbol {
    
    //Variables de nuestro Arbol Binario.
    public NodoArbol hijoIzquierdo, hijoDerecho;
    public String data;
    
    //Constructor de nuestro arbol.
    public NodoArbol(String data){
        this.data = data;
        hijoIzquierdo = null;
        hijoDerecho = null;
    }
    
    //Setters y getters del arbol binario.
    public NodoArbol getHijoIzquierdo() {
        return hijoIzquierdo;
    }

    public void setHijoIzquierdo(NodoArbol hijoIzquierdo) {
        this.hijoIzquierdo = hijoIzquierdo;
    }

    public NodoArbol getHijoDerecho() {
        return hijoDerecho;
    }

    public void setHijoDerecho(NodoArbol hijoDerecho) {
        this.hijoDerecho = hijoDerecho;
    }

    public String getData() {
        return data;
    }

    public void setData(String data) {
        this.data = data;
    }
    
}
