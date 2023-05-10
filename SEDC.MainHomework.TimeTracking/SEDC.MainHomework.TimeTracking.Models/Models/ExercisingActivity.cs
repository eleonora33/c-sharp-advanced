using SEDC.MainHomework.TimeTracking.Enum;

namespace SEDC.MainHomework.TimeTracking.Models.Models
{
    public class ExercisingActivity : BaseActivity
    {
        public ExerciseType ExerciseType { get; set; }

        public ExercisingActivity(ExerciseType exerciseType)
        {
            ExerciseType = exerciseType;
        }

        public override void StartActivity(User user)
        {
            base.StartActivity(user);
        }

        public override TimeSpan StopActivity()
        {
            return base.StopActivity();
        }
    }
}
