import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';

export enum AntragTyp {
  VERTRETUNG = 'VERTRETUNG',
  DIENSTBEFREIUNG = 'DIENSTBEFREIUNG',
  FORTBILDUNG = 'FORTBILDUNG',
  VERLEGUNG = 'VERLEGUNG',
  TAUSCH = 'TAUSCH',
  KLASSE_ABWESEND = 'KLASSE_ABWESEND',
  VERANSTALTUNG = 'VERANSTALTUNG'
}

@Component({
  imports: [FormsModule],
  selector: 'app-create-request',
  styleUrl: './create-request.css',
  templateUrl: './create-request.html',
})
export class CreateRequest {

  AntragTyp = AntragTyp;

  selectedType: AntragTyp | null = null;

  grund = '';

  datumVon = '';
  datumBis = '';

  zeitVon = '';
  zeitBis = '';

  veranstaltungsArt = '';

  vertretungsmaterial: string | null = null;

  unterrichtEintraege = [
    {
      datum: '',
      tag: '',
      stunde: null as number | null,
      raum: '',
      bemerkung: '',
      tauschMit: '',
      bemerkungDatum: '',
      bemerkungStunde: null as number | null,
      expanded: true
    }
  ];


  addEintrag(): void {
    this.unterrichtEintraege.push({
      datum: '',
      tag: '',
      stunde: null,
      raum: '',
      bemerkung: '',
      tauschMit: '',
      bemerkungDatum: '',
      bemerkungStunde: null,
      expanded: true
    });
  }

  toggleEintrag(index: number): void {
    this.unterrichtEintraege[index].expanded =
      !this.unterrichtEintraege[index].expanded;
  }

  removeEintrag(index: number): void {
    this.unterrichtEintraege.splice(index, 1);
  }


  absenden(): void {

    console.log({
      type: this.selectedType,
      grund: this.grund,
      datumVon: this.datumVon,
      datumBis: this.datumBis,
      zeitVon: this.zeitVon,
      zeitBis: this.zeitBis,
      veranstaltungsArt: this.veranstaltungsArt,
      vertretungsmaterial: this.vertretungsmaterial,
      unterrichtEintraege: this.unterrichtEintraege
    });

  }

}