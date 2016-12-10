## README ##

## 1. Warum Git? ##

Git ist der Shit unter den Version Controll Systems (VCS) und wird von den allermeisten Software-Buden genutzt. Mit Git ersparst du dir das Anlegen von "myProject_version01", "myProject_version02" usw. da Git jeden Bearbeitungsschritt den du registrierst im Verlauf dokumentiert und nur die Differenz zum jeweils voherigen abspeichert. Dadurch kann man beliebig viel und wesentlich kontrollierter "Rückgängig machen". Des Weiteren ist es hierdurch erst möglich, dass praktisch unendlich viele Entwickler am gleichen Projekt arbeiten, ohne etwas zu Zerstören. Git kann noch viel mehr, aber dafür konsultiere bitte die Suchmaschine deine (Nicht-)Vertrauens.

Konkret in unserem Fall ergibt sich darüber hinaus der Vorteil, dass ein gewisses Maß an Dokumentation, die ja zu 25% in die Endnote einfließt, durch Git quasi automatisch gegeben ist.


## 2. Wie zum Geier benutze ich das? ##

Alles andere kann nachgeschlagen werden, das wichtigste im workflow is jedoch in dieser Reihenfolge:
- $ git add "myFiles/*"
- $ git commit -m "My Message"
- $ git pull
- $ git push
- $ git checkout -b "mybranch"

HINWEIS:
Um Konflikte zwischen Änderungen zu vermeiden, am besten immer regelmäßig einen "pull" vor der Änderung und einen commit nach der Änderung.


## 3. Datei ohne Namen? Gitignore! ##

Mit .gitignore lassen sich Ausnahmen beim tracken von files festlegen. Teilweise generiert Unity temporäre Files u.a. beim Öffnen und Schließen des Editors. Falls du noch auf weitere solcher Fälle stößt, bitte hinzufügen, vor allem, wenn sie sich nur auf deinem PC befinden. 
Eigentlich sollte alles sonst soweit in den folgenden Dateien untergebracht sein:
- .gitignore
- unity.gitignore