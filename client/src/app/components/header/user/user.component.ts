import { Component } from '@angular/core';
import { NgIconComponent, provideIcons } from '@ng-icons/core';
import { saxArrowDownBold } from '@ng-icons/iconsax/bold';

import { MatIconModule } from '@angular/material/icon';

@Component({
  selector: 'app-user-box',
  standalone: true,
  imports: [NgIconComponent, MatIconModule],
  templateUrl: './user.component.html',
  styleUrl: './user.component.css',
  viewProviders: provideIcons({
    saxArrowDownBold,
  }),
})
export class UserBoxComponent {}
