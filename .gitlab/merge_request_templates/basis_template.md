De acordo com a [Estratégia de Verificação, Validação e Integração](https://foundation.basis.com.br/gerencia_configuracao.html#estrat%C3%A9gia-de-verifica%C3%A7%C3%A3o-valida%C3%A7%C3%A3o-e-integra%C3%A7%C3%A3o) definida no Foundation, os seguintes itens de check-list devem ser validados para aceitação do Merge Request:

- [ ] `liquibase` Uso de SQL na migrações
- [ ] `liquibase` Edição de changeset já aplicado
- [ ] `config` Níveis de logs nos arquivos de configuração globais
- [ ] `config` Configuração externalizada (vs fixa no código)
- [ ] `config` Dependências desnecessárias
- [ ] `qualidade` Nomenclatura REST - Uri Design
- [ ] `qualidade` Complexidade dos algoritmos
- [ ] `qualidade` Nomes das variáveis/métodos/classes
- [ ] `qualidade` Reinvenção de roda - classes Utils (usar commons, guava, lodash, ...)
- [ ] `qualidade` Código testável
- [ ] `qualidade` Pesquisa dentro de estrutura de repetição (Banco, WS, etc.)
