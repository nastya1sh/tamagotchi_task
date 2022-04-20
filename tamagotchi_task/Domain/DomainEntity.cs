namespace tamagotchi_task.Domain
{
    public abstract class DomainEntity
    {
        protected Guid _id;

        public DomainEntity()
        {
            _id = Guid.NewGuid(); //Если будут проблемы, сделаем вызов метода не в конструкторе
        }

        public Guid Prop { get => _id; }
    }
}
