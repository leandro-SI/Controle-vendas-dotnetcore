import * as moment from 'moment';
import { EstadoDto } from '../estado/estadoDto';

export class CidadeDto implements ICidadeDto {
    id: string;
    nome: string | undefined;
    estadoId: string | undefined;
    estado: EstadoDto | undefined;
    lastLoginTime: moment.Moment | undefined;
    creationTime: moment.Moment;
    
    constructor(data?: ICidadeDto) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    (<any>this)[property] = (<any>data)[property];
            }
        }
        else{
            this.id = "";
            this.nome = "";
            this.estadoId = "";
            this.estado = new EstadoDto();
            this.creationTime = <any>undefined; 

        }
    }

    init(data?: any) {
        if (data) {
            this.id = data["id"];
            this.nome = data["nome"];
            this.estadoId = data["estadoId"];
            this.estado = data["estado"];
            this.creationTime = data["creationTime"] ? moment(data["creationTime"].toString()) : <any>undefined;
            
        }
    }

    static fromJS(data: any): CidadeDto {
        data = typeof data === 'object' ? data : {};
        let result = new CidadeDto();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["id"] = this.id;
        data["nome"] = this.nome;
        data["estadoId"] = this.estadoId;
        data["estado"] = this.estado;
        data["creationTime"] = this.creationTime ? this.creationTime.toISOString() : <any>undefined;
        
        return data; 
    }

    clone(): CidadeDto {
        const json = this.toJSON();
        let result = new CidadeDto();
        result.init(json);
        return result;
    }

    Invlid(): boolean {
        let invalid = [];
        if (this.nome.length > 50)
            invalid.push(1);
        
        return invalid.length != 0;
    }
}

export interface ICidadeDto {
    id: string;
    nome: string | undefined;
    estadoId: string | undefined;
    estado: EstadoDto | undefined;
    creationTime: moment.Moment;
}