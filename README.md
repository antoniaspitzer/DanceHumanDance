# Game Production Prototype

GAP2IL Game Production 2 | SS 2025 | [John Kulha](https://github.com/John-HGB), [Wolfgang Hochleitner](https://github.com/hochleitner)

Dieses Repository beinhaltet die wichtigsten Vorbereitungen für den Game Production Prototype in Unity. Folgendes ist enthalten:

- `.gitignore`: Diese Datei beinhaltet alle Dinge, die *nicht* in das Repository committed werden sollen. Ein Unity-Projekt enthält viele Dateien und Verzeichnisse, die Informationen enthalten, die auf jedem Rechner unterschiedlich sind. Pfade, Programmeinstellungen, Cacheverzeichnisse usw. Diese gehören nicht ins Repository und werden durch das Vorhandensein dieser Datei automatisch ausgeschlossen.
- `.gitattributes`: In dieser Datei sind Einstellungen enthalten, wie Dateien im Repository gespeichert werden. Dies betrifft Zeilenumbrüche und vor allem die Verwendung des LFS (Large File Storage). Dieses wird benötigt, um größere (meist binäre) Dateien in Git speichern zu können.
- `README.md`: Die Information zu diesem Repository und die aktuelle Datei. Diese Infos sollen durch die Beschreibung zum eigenen Game Prototypen ersetzt werden.

## Verwenden des Repositorys

Die folgenden Schritte sollte zunächst eine Person im Team durchführen.

1. Das Repository mit einem Git Client der Wahl wie [GitKraken](https://www.gitkraken.com/) (möglich sind aber etwa auch [GitHub Desktop](https://desktop.github.com/), [Fork](https://git-fork.com/), [SmartGit](https://www.syntevo.com/smartgit/), uvm.) auf den eigenen Rechner in ein beliebiges Verzeichnis clonen.
2. Ein neues (leeres) Unity-Projekt irgendwo außerhalb des Repository-Ordners erstellen und einmal in Unity öffnen. Dazu den Unity Hub öffnen und "New Project" auswählen. Die Settings entsprechend den Vorgaben des Lehrenden einstellen und "Create project" wählen.
3. Nachdem das Projekt geöffnet und angezeigt wurde, Unity wieder schließen (ebenso VisualStudio bzw. den verwendeten Code Editor).
4. Den Unity-Projektordner in Explorer/Finder öffnen und alle Ordner und Dateien darin in den Repository-Ordner verschieben. Nach diesem Schritt sollte der Repository-Ordner direkt den `.git`-Ordner, die Ordner `Assets`, `Library`, `Packages` etc. sowie die bereits vorher enthaltenen Dateien `.gitignore` und `.gitattributes` enthalten. Dateien/Ordner, die mit `.` beginnen, sind unter macOS in der Regel nicht sichtbar und müssen explizit sichtbar geschaltet werden.
5. Die Änderungen committen und danach auf GitHub pushen.

Nun können die anderen Teammitglieder Schritt 1 ausführen und sich das Repository ebenfalls clonen. Alle haben nun denselben Stand.

## Erweitern des Projekts

- Nachdem Änderungen am Unity Projekt gemacht wurden, sollten diese in regelmäßigen Abständen committed und gepushed werden.
- Bevor am Projekt gearbeitet wird, immer einen "Pull" durchführen, um die aktuelle Version von GitHub zu erhalten.
- Kommunizieren! Sicherstellen, dass niemand sonst parallel am Projekt arbeitet. Dies führt schnell zu Merge-Konflikten.

## Anpassen dieser README-Datei

Diese Datei dient zum Beschreiben des eigenen Projekts. Während hier zu Beginn generische Informationen zum Startercode zu finden sind, sollte der Inhalt der Datei mit Informationen zum eigenen Projekt und dessen Verwendung ausgetauscht werden.
