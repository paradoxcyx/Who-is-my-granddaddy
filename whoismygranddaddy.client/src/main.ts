import { platformBrowserDynamic } from '@angular/platform-browser-dynamic';
import { registerLicense } from '@syncfusion/ej2-base';
import { AppModule } from './app/app.module';

registerLicense('Ngo9BigBOggjHTQxAR8/V1NAaF5cWWJCf0x/WmFZfVpgd19EZVZTTGYuP1ZhSXxXdkRjW39dcnFXTmFUWUw=');

platformBrowserDynamic().bootstrapModule(AppModule)
  .catch(err => console.error(err));

