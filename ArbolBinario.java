package evidencia2;
import java.util.*;

public class ArbolBinario {
    //Declaramos las variables que utilizaremos. 
    private Scanner sc = new Scanner(System.in);
    private NodoArbol raiz, apuntador;
    private String opcion, animalNuevo, cualidadNueva, animal;
    private String [] niveles;
    private boolean terminado = false;
    private int contador = 0, altura;
    
    public ArbolBinario()
    {
        //Creamos nuestro arbol con nuestra raiz.
        raiz = new NodoArbol("tiene cuernos");
        reiniciarApuntador();
        //Establecemos el hijo izquierdo y sus dos nodos hijos/hojas.
        apuntador.hijoIzquierdo = new NodoArbol("cuello largo");
        apuntador = apuntador.hijoIzquierdo;
        apuntador.hijoIzquierdo = new NodoArbol("jirafa");
        apuntador.hijoDerecho = new NodoArbol("vaca");
        reiniciarApuntador();
        //Establecemos el hijo derecho y sus dos nodos hijos/hojas.
        apuntador.hijoDerecho = new NodoArbol("alas");
        apuntador = apuntador.hijoDerecho;
        apuntador.hijoDerecho = new NodoArbol("tortuga");
        apuntador.hijoIzquierdo = new NodoArbol("perico");
    }
    
    //Metodo para reiniciar el auxilia a la raiz.
    private void reiniciarApuntador()
    {
        apuntador = raiz;
    }
    
    //Metodo que nos ayuda a saber si el arbol esta vacio.
    private boolean estaVacio()
    {
        return apuntador == null;
    }
    
    //Metodo para empezar el juego.
    public void juego()
    {
        
        //Hacemos que nuestro apuntador de a la raiz.
        reiniciarApuntador();
        //Si nuestro auxiliar(nodo) no es nulo y todavia no termina. 
        while(!estaVacio() && terminado != true)
        {
            //Si el hijo izquierdo del nodo no es nulo, significa que hay una cualidad.
            if(apuntador.hijoIzquierdo != null)
            {
                //Imprime la cualidad y da la opcion de si y no.
                System.out.println("¿"+apuntador.data+"?");
                opcion = sc.nextLine();
                //Si si es la cualidad, avanza a el hijo izquierdo del nodo.
                if("si".equals(opcion))
                {
                    apuntador = apuntador.hijoIzquierdo;
                }
                //Si no es la cualidad, avanza al hijo derecho del nodo.
                if("no".equals(opcion))
                {
                    apuntador = apuntador.hijoDerecho;
                }
            }
            //Si el hijo izquierdo del nodo si es nulo, significa que hay un animal.
            if(apuntador.hijoIzquierdo == null)
            {
                insertarNodo(apuntador.data);
            }
        }
    }
    
    //Metodo para insertar un nuevo animal al arbol.
    private void insertarNodo(String animalViejo)
    {
        //Imprimimos el animal del nodo, y se pregunta si es el animal que se esta pensando.
        System.out.println("¿El animal en el que estas pensando es un/una "+animalViejo+"?");
        opcion = sc.nextLine();
        
        //Si si es el animal, se avisa al usuario que se adivino.
        if("si".equals(opcion))
        {
            System.out.println("¡Tu animal es un/una "+animalViejo+"!");
            System.out.println();
            //Se le pregunta al usuario si quiere jugar de nuevo.
            System.out.println("¿Quieres jugar de nuevo?");
            opcion = sc.nextLine();
            //En caso de que si, reiniciamos el apuntador a la raiz.
            if("si".equals(opcion))
            {
                reiniciarApuntador();
            }
            //En caso de que no, le damos las gracias al usuario y convertimos terminado en true.
            if("no".equals(opcion))
            {
                System.out.println("Gracias por jugar.");
                terminado = true;
                opcion = "";
            }
        }
        
        //Si no es el animal, significa que perdemos y preguntamos por el nuevo animal.
        if("no".equals(opcion))
        {
            //Se le imprime al usaurio que se perdio el juego.
            System.out.println("¡Perdi el juego!");
            System.out.println();
            //Se le pregunta por un animal nuevo y una cualidad nueva.
            System.out.println("¿En que animal estabas pensando?");
            animalNuevo = sc.nextLine();
            System.out.println("¿Que cualidad tiene este animal?");
            cualidadNueva = sc.nextLine();
            //Intercambiamos el animal viejo por la nueva cualidad.
            apuntador.data = cualidadNueva;
            //Creamos dos nodos, uno para el animal viejo que se guarda en el hijo izquierdo del nodo actual.
            //Y el otro para el animal viejo que se guarda en el hijo derecho del nodo actual.
            apuntador.hijoIzquierdo = new NodoArbol(animalNuevo);
            apuntador.hijoDerecho = new NodoArbol(animalViejo);
            
            //Se le pregunta al usuario si quiere jugar de nuevo.
            System.out.println("¿Quieres jugar de nuevo?");
            opcion = sc.nextLine();
            
            //En dado caso de que si, reiniciamos nuestro apuntador.
            if("si".equals(opcion))
            {
                reiniciarApuntador();
            }
            //En dado caso de que no, le damos las gracias al usuario y convertimos terminado en true.
            if("no".equals(opcion))
            {
                System.out.println("Gracias por jugar.");
                terminado = true;
            }
        }
    }
    
    public void recorridoPreorden()
    {
        ayudantePreorden(raiz);
    }
    
    private void ayudantePreorden(NodoArbol nodo)
    {
        if(nodo == null)
        {
            return;
        }
        else
        {
            contador++;
            System.out.println(contador+" "+nodo.data);
            ayudantePreorden(nodo.hijoIzquierdo);
            ayudantePreorden(nodo.hijoDerecho);
        }
    }    
}
