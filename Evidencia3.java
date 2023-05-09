package evidencia3;
import java.io.*;
import java.util.logging.Level;
import java.util.logging.Logger;

public class Evidencia3 {

    public static void main(String[] args) {
        
        GrafoTransporte Metodo = new GrafoTransporte();
        String Columna1, Columna4, Columna5;
        int Columna2, Columna3, Columna6, Columna7, Columna8;

        String camino = "/Users/artur/OneDrive/Documentos/Java Proyects/Evidencia 3/ModeloTransporte.csv";
        String linea = "";
        try {
            BufferedReader br = new BufferedReader(new FileReader(camino));

            while ((linea = br.readLine()) != null) {
                String[] values = linea.split(",");
                Columna1 = values[0];
                Columna2 = Integer.parseInt(values[1]);
                Columna3 = Integer.parseInt(values[2]);
                Columna4 = values[3];
                Columna5 = values[4];
                Columna6 = Integer.parseInt(values[5]);
                Columna7 = Integer.parseInt(values[6]);
                Columna8 = Integer.parseInt(values[7]);
                Metodo.AgregarLista(Columna1, Columna2, Columna3, Columna4, Columna5, 
                Columna6, Columna7, Columna8);
                //System.out.println(values[0]);
            }

        } catch (FileNotFoundException ex) {
            Logger.getLogger(Evidencia3.class.getName()).log(Level.SEVERE, null, ex);
        } catch (IOException ex) {
            Logger.getLogger(Evidencia3.class.getName()).log(Level.SEVERE, null, ex);
        }
        System.out.println("MATRIZ INICIAL");
        Metodo.ImprimeLista();
        Metodo.ResolverProblema();
        System.out.println("\n\nMATRIZ RESULTANTE");
        Metodo.ImprimeLista();
    }
}
    
