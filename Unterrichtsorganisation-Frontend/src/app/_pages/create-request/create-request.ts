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

  absenden(): void {

    console.log({
      type: this.selectedType,
      grund: this.grund,
      datumVon: this.datumVon,
      datumBis: this.datumBis,
      zeitVon: this.zeitVon,
      zeitBis: this.zeitBis,
      veranstaltungsArt: this.veranstaltungsArt
    });

  }

}