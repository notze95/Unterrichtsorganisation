# Unterrichtsorganisation

Programmiersprachen:
- Frontend: 
- Backend:
## Zeitplanung

### Webfrontend:
  - Login
  - Übersichtsseite (je nach Berechtigung mit 2Tabs für genehmigen oder ohne)
  - PopUp für die Anträge zu stellen
  - Popup um die Anträge zu genehmigen
  - Adminseite (Passwortreset, (Neue Abteilung anlegen, löschen), (Lehrer anlegen, ändern, löschen), Berechtigungen zuweisen, Logs anzeigen
  - Fehlerseite/Popup

### Backend:
  - Datenbank:
      - Tabelle User: ID_Lehrer PK, Name Lehrer, Username, Password, Rolle der Lehrer, Kürzel
      - Tabelle Antraege: Status der Anträge, ID_Lehrer FK, Datum, ID_Antrag PK, Antrag json
      - Tabelle Abteilungen: Abteilung PK, ID_Lehrer FK
   
    Code:
