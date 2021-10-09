# Grupa4-ASD


### Članovi tima:

  •	Hajradinović Ajša
  
  •	Zaimović Sara
  
  •	Bašalić Dženan
 
Link: http://hospitalis.azurewebsites.net/

### Opis teme:

  •	Vjerovatno ste mnogo puta naišli na neprilike uzrokovane slabom organizacijom sistema i osoblja u javnim ustanovama. To je posebno primjetno u bolnicama, gdje se stvaraju ogromne gužve, što, svakako, nije dobro, naročito za već bolesne ljude. Međutim, aplikacija „Hospitalis“ rješava i Vas i Vaše najbliže tih neprilika. Omogućava Vam da birate termin i doktora kod kojeg želite obaviti pregled. Uz to, imate sve važne podatke i dokumente na jednom mjestu. Također, nakon obavljenog pregleda, možete dati Vašu ocjenu osoblju.
  
### Funkcionalnost web servisa:

  •	Da bi se dopustilo kreiranje novog računa za doktora, na unesenu e-mail adresu šalje se verifikacioni kod. Unosom ispravnog koda kreira se novi račun.

### Procesi: 

  •	Korisnik može potražiti željene informacije o strukturi osoblja. 
  •	Korisnik kreira nalog: unosi lične podatke (ime, prezime, username, password, spol, datum rođenja, kontakt-telefon), zatim bira željeni odjel, doktora i neki od termina za pregled. Ubuduće, za zakazivanje pregleda koristi se postojećim nalogom.
  
  •	Doktor, također, treba imati kreiran nalog.
  •	Doktor je zadužen za validaciju termina, koje korisnici biraju, u skladu sa svojim obavezama.
  •	Pri obavljanju pregleda, doktor je dužan napisati izvještaj o pregledu. U slučaju uspostavljanja određene dijagnoze, u skladu sa njom, propisati recept ili uputnicu. 
  •	Pacijent ima mogućnost da ocijeni usluge osoblja, kao i cjelokupni tretman.
  
  •	Admin je zadužen za regulisanje kreiranih naloga.
  
  •	U slučaju otkazivanja pregleda, doktor je dužan napisati obavještenje pacijentima.
  
  
### Funkcionalnosti:
  
  •	Mogućnost kreiranja i ažuriranja korisničkog računa;
  
  •	Mogućnost zakazivanja pregleda gdje će pacijentu biti prikazani svi postojeći termini (zauzeti i dostupni). Pregled će zakazati tako što će željeni termin (ukoliko je isti dostupan) označiti zakazanim, a potom sačuvati promjene;
  
  •	Mogućnost uvida u dokumentaciju pregleda;
  
  •	Mogućnost uvida u strukturu osoblja i odjela;
  
  •	Mogućnost ocjene pregleda;
  
  •	Mogućnost izdavanja dokumenata pregleda;
  
  •	Mogućnost potvrde termina pregleda;
  
  •	Mogućnost provjere naručenih pacijenata.

  
### Akteri:

  •	Pacijent – osoba koja može potražiti informacije o ustanovi, kreirati nalog te zakazati pregled, ocjenjivati usluge i čitati obavještenja.
  
  •	Doktor – osoba koja mora imati kreiran nalog, kreira termine pregleda, izdaje izvještaje o pregledu, eventualno uputnice i recepte, te izdaje obavještenja.
  
  •	Admin – osoba koja ažurira podatke, održava bazu podataka i reguliše prava pristupa.
