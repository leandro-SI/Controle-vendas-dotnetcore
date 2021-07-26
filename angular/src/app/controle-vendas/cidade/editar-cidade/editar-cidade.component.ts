import { Component, EventEmitter, Injector, Input, OnInit, Output } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { AppComponentBase } from '@shared/app-component-base';
import { CidadeDto } from '@shared/models/cidade/cidadeDto';
import { EstadoDto } from '@shared/models/estado/estadoDto';
import { EstadoDtoPagedResultDto } from '@shared/models/estado/estadoDtoPagedResultDto';
import { CidadeServiceProxy, EstadoServiceProxy } from '@shared/service-proxies/service-proxies';
import { finalize } from 'rxjs/internal/operators/finalize';
import { Subscription } from 'rxjs/internal/Subscription';


@Component({
  selector: 'app-editar-cidade',
  templateUrl: './editar-cidade.component.html',
  styleUrls: ['./editar-cidade.component.css']
})
export class EditarCidadeComponent extends AppComponentBase implements OnInit {
  saving = false;
  myForm: FormGroup;
  cidade: CidadeDto;
  estadoSub: Subscription;
  estadoLista: EstadoDto[] = [];
  @Output() onSave = new EventEmitter<any>();
  @Input() id;

  /*SUBSCRIBE S */
  subscribParams: Subscription;
  /*FIM SUBSCRIBE S */

  constructor(injector: Injector,
    private _router: Router,
    private router: ActivatedRoute,
    private _estadoService: EstadoServiceProxy,
    private _cidadeService: CidadeServiceProxy,
  ) {
    super(injector);

    this.cidade = new CidadeDto();
  }

  ngOnInit(): void {

    this.prepareSelects();

    if (this.id == undefined) {
      this.subscribParams = this.router.params.subscribe((parans: any) => {
        this.id = parans['id'];
        this.carregarDados();
      });
    }
    else {
      this.carregarDados();
    }

  }

  private prepareSelects() {
    this.estadoSub = this._estadoService.getAll("", 1, 0, 1000)
      .subscribe((result: EstadoDtoPagedResultDto) => {
        this.estadoLista = result.items;
      });
  }

  private carregarDados() {
    this._cidadeService.get(this.id).subscribe((result) => {
      this.cidade = result;
    });
  }

  public salvar() {
    this.saving = true;

    if (this.cidade.Invlid()) {
      // this.notify.error(this.l('mensagemDeErro'), this.l('Error'), { position: 'top-end', timer: 4000 });
      return;
    }
    this.saving = false;

    this._cidadeService
      .update(this.cidade)
      .pipe(
        finalize(() => {
          this.saving;
        })
      )
      .subscribe((ret) => {
        this.notify.success(this.l('SavedSuccessfully'), null, { position: 'top-end', timer: 4000 });
        this.onSave.emit();
        this._router.navigate(['/app/cidade/']);
      });

  }

  public voltar(){
    this._router.navigate(['/app/cidades/']);
  }

  ngOnDestroy() {
    if (this.subscribParams) this.subscribParams.unsubscribe();
  }

}
