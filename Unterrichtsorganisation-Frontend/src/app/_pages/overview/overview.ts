import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Router } from '@angular/router';

interface Antrag {
  id: string;
  datum: string;
  status: string;
}

@Component({
  selector: 'app-overview',
  imports: [CommonModule],
  styleUrl: './overview.css',
  templateUrl: './overview.html',
})
export class Overview {
  constructor(private router: Router) { }


  userName = 'Max Mustermann';

  canApprove = true;

  zuGenehmigen: Antrag[] = [
    {
      id: 'A-1001',
      datum: '19.10.2026',
      status: 'Offen'
    },
    {
      id: 'A-1002',
      datum: '18.10.2026',
      status: 'Offen'
    }
  ];

  entwuerfe: Antrag[] = [
    {
      id: 'A-2001',
      datum: '17.10.2026',
      status: 'Entwurf'
    },
    {
      id: 'A-2002',
      datum: '16.10.2026',
      status: 'Entwurf'
    }
  ];

  gesendeteAntraege: Antrag[] = [
    {
      id: 'A-3001',
      datum: '15.10.2026',
      status: 'Wartet auf Genehmigung'
    },
    {
      id: 'A-3002',
      datum: '14.10.2026',
      status: 'Genehmigt'
    }
  ];

  neuerAntrag(): void {
    this.router.navigate(['/create-request']);
  }

  openAntrag(id: string): void {
    console.log(id);
  }

  logout(): void {
    console.log('Logout');
  }
}
``