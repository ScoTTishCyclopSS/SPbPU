package server;

import java.io.DataInputStream;
import java.io.DataOutputStream;
import java.io.IOException;
import java.net.Socket;

class ClientHandler implements Runnable {

    private static Socket clientDialog;
    
    public ClientHandler(Socket client) {
        ClientHandler.clientDialog = client;
    }
    
    @Override
    public void run() {
        try {
            DataInputStream in = new DataInputStream(clientDialog.getInputStream());
            System.out.println("DataInputStream created");
            DataOutputStream out = new DataOutputStream(clientDialog.getOutputStream());
            System.out.println("DataOutputStream  created");
            while (!clientDialog.isClosed()) {
                System.out.println("Server reading from channel");
                String entry = in.readUTF();
                System.out.println("READ from clientDialog message - " + entry);
                if (entry.equalsIgnoreCase("quit")) {
                    out.writeUTF("Server reply - " + entry + " - OK");
                    Thread.sleep(3000);
                    break;
                }
                out.writeUTF("Server reply - " + entry + " - OK");
                out.flush();
            }
            System.out.println("Client disconnected");
            in.close();
            out.close();
            clientDialog.close();
            System.out.println("Closing connections & channels - DONE.");
        } catch (IOException e) {
            e.printStackTrace();
        } catch (InterruptedException e) {
            e.printStackTrace();
        }
    }  
}
