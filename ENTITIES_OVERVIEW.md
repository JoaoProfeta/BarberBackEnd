# Sistema de Agendamento de Barbearia - Estrutura de Entidades

## Visão Geral

Este documento descreve a estrutura das entidades do sistema de agendamento de barbearia, seguindo os princípios de Domain-Driven Design (DDD) com arquitetura limpa.

## Entidades Principais

### 1. **Entity (Classe Base)**
- **Responsabilidade**: Classe abstrata base para todas as entidades
- **Propriedades**:
  - `Id`: Identificador único (Guid)
- **Funcionalidades**:
  - Implementa `IEquatable<Entity>` para comparação por ID
  - Gera automaticamente um novo Guid no construtor

### 2. **User**
- **Responsabilidade**: Representa um usuário do sistema (base para clientes e profissionais)
- **Propriedades**:
  - `Name`: Nome do usuário
  - `Email`: Email do usuário
  - `Phone`: Telefone do usuário
  - `UserType`: Tipo de usuário (Customer, Professional, Owner, Admin)
  - `CreatedAt`: Data de criação
  - `IsActive`: Status ativo/inativo
- **Funcionalidades**:
  - Atualização de dados pessoais
  - Ativação/desativação do usuário

### 3. **Customer**
- **Responsabilidade**: Representa clientes que fazem agendamentos
- **Propriedades**:
  - `Name`: Nome do cliente
  - `Email`: Email do cliente
  - `Phone`: Telefone do cliente
  - `CreatedAt`: Data de criação
  - `IsActive`: Status ativo/inativo
  - `Schedulings`: Lista de agendamentos do cliente
- **Funcionalidades**:
  - Atualização de dados pessoais
  - Ativação/desativação

### 4. **Professional**
- **Responsabilidade**: Representa profissionais da barbearia
- **Propriedades**:
  - `UserId`: Referência ao usuário base
  - `Description`: Descrição/biografia do profissional
  - `CommissionPercentage`: Percentual de comissão
  - `Status`: Status de disponibilidade (Disponível/Indisponível)
  - `CreatedAt`: Data de criação
  - `IsActive`: Status ativo/inativo
- **Relacionamentos**:
  - `User`: Usuário base
  - `Services`: Serviços que o profissional pode realizar
  - `Availabilities`: Horários de trabalho semanais
  - `TimeBlocks`: Bloqueios específicos de horário
- **Funcionalidades**:
  - Gerenciamento de serviços oferecidos
  - Definição de disponibilidade semanal
  - Criação de bloqueios temporários
  - Verificação de disponibilidade em horário específico

### 5. **Service**
- **Responsabilidade**: Representa serviços oferecidos pela barbearia
- **Propriedades**:
  - `Name`: Nome do serviço
  - `Description`: Descrição do serviço
  - `Price`: Preço do serviço
  - `DurationInMinutes`: Duração em minutos
  - `ServiceStatus`: Status (Disponível/Indisponível)
  - `CreatedAt`: Data de criação
  - `IsActive`: Status ativo/inativo
- **Relacionamentos**:
  - `Professionals`: Profissionais que podem realizar o serviço
- **Funcionalidades**:
  - Atualização de informações do serviço
  - Gerenciamento de profissionais associados

### 6. **Scheduling**
- **Responsabilidade**: Representa um agendamento
- **Propriedades**:
  - `CustomerId`: Referência ao cliente
  - `SchedulingTime`: Data e hora do agendamento
  - `Observations`: Observações do agendamento
  - `SchedulingStatus`: Status (Aceito, Rejeitado, Pendente)
  - `CreatedAt`: Data de criação
  - `TotalPrice`: Preço total do agendamento
- **Relacionamentos**:
  - `Customer`: Cliente que fez o agendamento
  - `SchedulingProfessionalsServices`: Serviços e profissionais do agendamento
- **Funcionalidades**:
  - Adição/remoção de serviços profissionais
  - Cálculo do preço total
  - Estimativa de tempo de término
  - Verificação se pode ser cancelado

### 7. **Availability**
- **Responsabilidade**: Define horários de trabalho semanais dos profissionais
- **Propriedades**:
  - `ProfessionalId`: Referência ao profissional
  - `DayOfWeek`: Dia da semana
  - `StartTime`: Hora de início
  - `EndTime`: Hora de término
  - `IsActive`: Status ativo/inativo
- **Funcionalidades**:
  - Atualização de horários de trabalho
  - Verificação se está disponível em horário específico

### 8. **TimeBlock**
- **Responsabilidade**: Representa bloqueios específicos de horário
- **Propriedades**:
  - `ProfessionalId`: Referência ao profissional
  - `StartDateTime`: Data/hora de início do bloqueio
  - `EndDateTime`: Data/hora de término do bloqueio
  - `Reason`: Motivo do bloqueio
  - `IsActive`: Status ativo/inativo
  - `CreatedAt`: Data de criação
- **Funcionalidades**:
  - Atualização do período de bloqueio
  - Verificação se está bloqueando um horário específico

## Entidades de Relacionamento

### 9. **ProfessionalServiceJoint**
- **Responsabilidade**: Relaciona profissionais com serviços que podem realizar
- **Propriedades**:
  - `ServiceId`: Referência ao serviço
  - `ProfessionalId`: Referência ao profissional
- **Relacionamentos**:
  - `Professional`: Profissional
  - `Service`: Serviço

### 10. **SchedulingProfessionalServiceJoint**
- **Responsabilidade**: Relaciona agendamentos com combinações profissional-serviço
- **Propriedades**:
  - `SchedulingId`: Referência ao agendamento
  - `ProfessionalServiceJointId`: Referência à combinação profissional-serviço
- **Relacionamentos**:
  - `Scheduling`: Agendamento
  - `ProfessionalServiceJoint`: Combinação profissional-serviço

## Enums

### EAvailabilityStatus
- `Avaliable = 1`
- `Unavailable = 2`

### ESchedulingStatus
- `Accepted = 1`
- `Rejected = 2`
- `Pending = 3`

### EDayOfWeek
- `Sunday = 0` até `Saturday = 6`

### EUserType
- `Customer = 1`
- `Professional = 2`
- `Owner = 3`
- `Admin = 4`

## Fluxo de Agendamento

1. **Cliente** (`Customer`) faz um agendamento
2. Escolhe **data/hora** específica
3. Seleciona **serviços** e **profissionais** específicos para cada serviço
4. Sistema verifica **disponibilidade** do profissional:
   - Verifica `Availability` (horário de trabalho semanal)
   - Verifica `TimeBlock` (bloqueios específicos)
   - Verifica agendamentos existentes
5. Cria `Scheduling` com status `Pending`
6. Adiciona `SchedulingProfessionalServiceJoint` para cada combinação serviço-profissional
7. Calcula preço total baseado nos serviços

## Principais Funcionalidades de Negócio

- **Verificação de Disponibilidade**: Considera horários de trabalho, bloqueios e agendamentos existentes
- **Múltiplos Serviços**: Um agendamento pode ter vários serviços com profissionais diferentes
- **Gestão de Preços**: Cálculo automático baseado nos serviços selecionados
- **Flexibilidade de Horários**: Profissionais podem ter horários diferentes por dia da semana
- **Bloqueios Temporários**: Possibilidade de bloquear horários específicos (férias, folgas, etc.)
- **Auditoria**: Todas as entidades têm controle de criação e status ativo/inativo