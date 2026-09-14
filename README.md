# Unterrichtsorganisation

Programmiersprachen:
- Frontend: Angular
- Backend: C# (MVC-pattern)
- Datenbank: Entity-Framework Core
## Zeitplanung

### Webfrontend:
  - Login
  - Übersichtsseite (je nach Berechtigung mit 2Tabs für genehmigen oder ohne)
  - PopUp für die Anträge zu stellen
  - Popup um die Anträge zu genehmigen
  - Adminseite (Passwortreset, (Neue Abteilung anlegen, löschen), (Lehrer anlegen, ändern, löschen), Berechtigungen zuweisen, Logs anzeigen
  - Fehlerseite/Popup

### Backend:
  - Datenbank (DESC andbindung der csv daten):
      - Tabelle User: ID_Lehrer PK, Name Lehrer, Username, Password, Rolle der Lehrer, Kürzel
      - Tabelle Antraege: Status der Anträge, ID_Lehrer FK, Datum, ID_Antrag PK, Antrag json
      - Tabelle Abteilungen: Abteilung PK, ID_Lehrer FK
   
  - Schnittstellen:
      - /login (Token (muss noch genau geklärt werden), Berechtigungsstufe)
      - get /overview ()
      - /create-form
      - /get-form
      - /password-reset
      - /department(anlege, löschen, ändern)
      - /teacher(anlegen, löschen, ändern)
      - /grant-rights
      - /logs
