import { Component } from '@angular/core';
import { MatDividerModule } from '@angular/material/divider';
import { MatListModule } from '@angular/material/list';
import { NgIconComponent, provideIcons } from '@ng-icons/core';
import { saxHome2Outline, saxDirectOutline } from '@ng-icons/iconsax/outline';

import { RouterLink } from '@angular/router';

import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-side-bar',
  standalone: true,
  imports: [
    NgIconComponent,
    MatListModule,
    MatDividerModule,
    RouterLink,
    CommonModule,
  ],
  templateUrl: './side-bar.component.html',
  styleUrl: './side-bar.component.css',
  viewProviders: [provideIcons({ saxHome2Outline, saxDirectOutline })],
})
export class SideBarComponent {
  activeItem: string = 'dashboard';

  activateMenu(page: string) {
    this.activeItem = page;
  }
}
