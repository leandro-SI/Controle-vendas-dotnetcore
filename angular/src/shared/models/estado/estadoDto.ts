import * as moment from 'moment';

export class EstadoDto implements IEstadoDto {
    id: string;
    nome: string | undefined;
    sigla: string | undefined;
    lastLoginTime: moment.Moment | undefined;
    creationTime: moment.Moment;
    
    constructor(data?: IEstadoDto) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    (<any>this)[property] = (<any>data)[property];
            }
        }
        else{
            this.id = "";
            this.nome = "";
            this.sigla = "";
            this.creationTime = <any>undefined; 

        }
    }

    init(data?: any) {
        if (data) {
            this.id = data["id"];
            this.nome = data["nome"];
            this.sigla = data["sigla"];
            this.creationTime = data["creationTime"] ? moment(data["creationTime"].toString()) : <any>undefined;
            
        }
    }

    static fromJS(data: any): EstadoDto {
        data = typeof data === 'object' ? data : {};
        let result = new EstadoDto();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["id"] = this.id;
        data["nome"] = this.nome;
        data["sigla"] = this.sigla;
        data["creationTime"] = this.creationTime ? this.creationTime.toISOString() : <any>undefined;
        
        return data; 
    }

    clone(): EstadoDto {
        const json = this.toJSON();
        let result = new EstadoDto();
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

export interface IEstadoDto {
    id: string;
    nome: string | undefined;
    sigla: string | undefined;
    creationTime: moment.Moment;
}