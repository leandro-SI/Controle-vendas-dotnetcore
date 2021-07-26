import { Component, EventEmitter, Injector, OnInit, Output } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { AppComponentBase } from '@shared/app-component-base';
import { CreateCidadeDto } from '@shared/models/cidade/createCidadeDto';
import { EstadoDto } from '@shared/models/estado/estadoDto';
import { EstadoDtoPagedResultDto } from '@shared/models/estado/estadoDtoPagedResultDto';
import { CidadeServiceProxy, EstadoServiceProxy } from '@shared/service-proxies/service-proxies';
import { finalize } from 'rxjs/internal/operators/finalize';
import { Subscription } from 'rxjs/internal/Subscription';

@Component({
  selector: 'app-criar-cidade',
  templateUrl: './criar-cidade.component.html',
  styleUrls: ['./criar-cidade.component.css']
})
export class CriarCidadeComponent extends AppComponentBase implements OnInit {
  cidade: CreateCidadeDto;
  myForm: FormGroup;
  saving = false;
  status: boolean = true;
  estadoLista: EstadoDto[] = [];
  estadoSub: Subscription;
  @Output() onSave = new EventEmitter<any>();  

  constructor(injector: Injector,
    private _router: Router,
    private _estadoService: EstadoServiceProxy,
    private _cidadeService: CidadeServiceProxy,
  ) {
    super(injector);

    this.cidade = new CreateCidadeDto();
 }

  ngOnInit(): void {
    this.prepareSelects();
  }

  private prepareSelects() {
    this.estadoSub = this._estadoService.getAll("", 1, 0, 1000)
    .subscribe((result: EstadoDtoPagedResultDto) => {
      this.estadoLista = result.items;
    });

  }

  public salvar() {

    this.saving = true;
   
    if (this.cidade.Invlid())
    {
      this.notify.error(this.l('mensagemDeErro'), this.l('Error'), { position: 'top-end', timer: 4000 });
      return;
    }
    this.saving = false;
    this._cidadeService
      .create(this.cidade)
      .pipe(
        finalize(() => {
          this.saving;
        })
      )
      .subscribe((ret) => {
        this.cidade.id = ret.id;
        this.notify.success(this.l('SavedSuccessfully'), null, { position: 'top-end', timer: 4000 });
        this.onSave.emit();
        this._router.navigate(['/app/cidade/']);
      });

  }

  public voltar() {
    this._router.navigate(['/app/cidade/']);
  }
}
