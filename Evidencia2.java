package evidencia2;
import java.util.*;
public class Evidencia2 {
    
    public static void main(String[] args) 
    {
        //Conseguimos nuestro nuevo arbolito para llamar los metodos y declaramos variables.
        ArbolBinario arbolito = new ArbolBinario();
        Scanner sc = new Scanner(System.in);
        String opcion;
        //Llamamos a nuestro arbol inicial.
        
        //Imprimimos instrucciones al usuario.
        System.out.println("---------¡Bienvenido al juego!---------");
        System.out.println("| Por favor ingresa las opciones asi. |");
        System.out.println("|      en minusculas, por favor.      |");
        System.out.println("|      (si)                 (no)      |");
        System.out.println("---------------------------------------");
        opcion = "si";
        
        //Empieza loop para saber si seguir jugando o no.
        do{
            System.out.println("¿Quieres jugar? ");
            opcion = sc.nextLine();
            
            //Si se da la opcion que si, inicia el juego.
            if("si".equals(opcion))
            {
                arbolito.juego();
            }
            //Si se da la opcion que no, termina el juego.
            if("no".equals(opcion))
            {
                System.out.println("El juego se termino.");
                break;
            }
        }while("no".equals(opcion));
        System.out.println("--- Este fue todo el arbol del juego. ---");
        System.out.println();
        arbolito.recorridoPreorden();
 
        
    }
}
    

