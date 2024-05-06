import { Component } from '@angular/core';

import { NgIconComponent, provideIcons } from '@ng-icons/core';
import { saxMessageBold, saxNotificationBold } from '@ng-icons/iconsax/bold';

import { MatIconModule } from '@angular/material/icon';

import { UserBoxComponent } from '../header/user/user.component';

@Component({
  selector: 'app-header',
  standalone: true,
  imports: [NgIconComponent, MatIconModule, UserBoxComponent],
  templateUrl: './header.component.html',
  styleUrl: './header.component.css',
  viewProviders: provideIcons({
    saxNotificationBold,
    saxMessageBold,
  }),
})
export class HeaderComponent {}
