document.addEventListener('DOMContentLoaded', function () {
    initProjectForm();
    initSkillForm();
    initCourseForm();
    initBlogForm();
    initFileUploads();
    initSkillRangeSlider();
});

function initProjectForm() {
    const form = document.getElementById('addProjectForm');
    if (!form) return;

    form.addEventListener('submit', async function (e) {
        e.preventDefault();
        const formData = new FormData(this);
        const submitBtn = this.querySelector('button[type="submit"]');

        try {
            submitBtn.disabled = true;
            submitBtn.innerHTML = '<i class="fa-solid fa-circle-notch fa-spin"></i> Adding...';

            const response = await fetch('/Projects/Create', {
                method: 'POST',
                body: formData,
                headers: {
                    'RequestVerificationToken': document.querySelector('input[name="__RequestVerificationToken"]').value
                }
            });

            const result = await response.json();
            if (result.success) {
                showToast('Success', result.message, 'success');
                this.reset();
                setTimeout(() => location.reload(), 1500);
            } else {
                showToast('Error', result.message || 'Failed to add project', 'error');
            }
        } catch (err) {
            showToast('Error', 'An error occurred. Please try again.', 'error');
        } finally {
            submitBtn.disabled = false;
            submitBtn.innerHTML = '<i class="fa-solid fa-plus"></i> Add Project';
        }
    });
}

function initSkillForm() {
    const form = document.getElementById('addSkillForm');
    if (!form) return;

    form.addEventListener('submit', async function (e) {
        e.preventDefault();
        const formData = new FormData(this);
        const submitBtn = this.querySelector('button[type="submit"]');

        try {
            submitBtn.disabled = true;
            submitBtn.innerHTML = '<i class="fa-solid fa-circle-notch fa-spin"></i> Adding...';

            const response = await fetch('/Skills/Create', {
                method: 'POST',
                body: formData,
                headers: {
                    'RequestVerificationToken': document.querySelector('input[name="__RequestVerificationToken"]').value
                }
            });

            const result = await response.json();
            if (result.success) {
                showToast('Success', result.message, 'success');
                this.reset();
                setTimeout(() => location.reload(), 1500);
            } else {
                showToast('Error', result.message || 'Failed to add skill', 'error');
            }
        } catch (err) {
            showToast('Error', 'An error occurred. Please try again.', 'error');
        } finally {
            submitBtn.disabled = false;
            submitBtn.innerHTML = '<i class="fa-solid fa-plus"></i> Add Skill';
        }
    });
}

function initCourseForm() {
    const form = document.getElementById('addCourseForm');
    if (!form) return;

    const youtubeInput = document.getElementById('courseYouTube');
    const thumbnailPreview = document.getElementById('courseThumbnailPreview');

    if (youtubeInput && thumbnailPreview) {
        youtubeInput.addEventListener('input', function () {
            const url = this.value;
            const videoId = extractYouTubeId(url);
            if (videoId) {
                thumbnailPreview.src = 'https://img.youtube.com/vi/' + videoId + '/hqdefault.jpg';
            } else {
                thumbnailPreview.src = '/images/youtube-placeholder.jpg';
            }
        });
    }

    form.addEventListener('submit', async function (e) {
        e.preventDefault();
        const formData = new FormData(this);
        const submitBtn = this.querySelector('button[type="submit"]');

        try {
            submitBtn.disabled = true;
            submitBtn.innerHTML = '<i class="fa-solid fa-circle-notch fa-spin"></i> Adding...';

            const response = await fetch('/Courses/Create', {
                method: 'POST',
                body: formData,
                headers: {
                    'RequestVerificationToken': document.querySelector('input[name="__RequestVerificationToken"]').value
                }
            });

            const result = await response.json();
            if (result.success) {
                showToast('Success', result.message, 'success');
                this.reset();
                thumbnailPreview.src = '/images/youtube-placeholder.jpg';
                setTimeout(() => location.reload(), 1500);
            } else {
                showToast('Error', result.message || 'Failed to add course', 'error');
            }
        } catch (err) {
            showToast('Error', 'An error occurred. Please try again.', 'error');
        } finally {
            submitBtn.disabled = false;
            submitBtn.innerHTML = '<i class="fa-solid fa-plus"></i> Add Course';
        }
    });
}

function initBlogForm() {
    const form = document.getElementById('addBlogForm');
    if (!form) return;

    form.addEventListener('submit', async function (e) {
        e.preventDefault();
        const formData = new FormData(this);
        const submitBtn = this.querySelector('button[type="submit"]');

        try {
            submitBtn.disabled = true;
            submitBtn.innerHTML = '<i class="fa-solid fa-circle-notch fa-spin"></i> Adding...';

            const response = await fetch('/Blog/Create', {
                method: 'POST',
                body: formData,
                headers: {
                    'RequestVerificationToken': document.querySelector('input[name="__RequestVerificationToken"]').value
                }
            });

            const result = await response.json();
            if (result.success) {
                showToast('Success', result.message, 'success');
                this.reset();
                setTimeout(() => location.reload(), 1500);
            } else {
                showToast('Error', result.message || 'Failed to add blog post', 'error');
            }
        } catch (err) {
            showToast('Error', 'An error occurred. Please try again.', 'error');
        } finally {
            submitBtn.disabled = false;
            submitBtn.innerHTML = '<i class="fa-solid fa-plus"></i> Add Blog Post';
        }
    });
}

function initFileUploads() {
    document.querySelectorAll('.file-upload-zone input[type="file"]').forEach(input => {
        input.addEventListener('change', function () {
            const zone = this.closest('.file-upload-zone');
            const placeholder = zone.querySelector('.upload-placeholder');
            const preview = zone.querySelector('.upload-preview');
            const previewImg = preview ? preview.querySelector('.preview-image') : null;

            if (this.files && this.files.length > 0) {
                if (placeholder) placeholder.classList.add('d-none');
                if (preview) preview.classList.remove('d-none');
                if (previewImg) {
                    const reader = new FileReader();
                    reader.onload = function (e) {
                        previewImg.src = e.target.result;
                    };
                    reader.readAsDataURL(this.files[0]);
                }
            }
        });

        const removeBtn = zone.querySelector('.btn-remove-file');
        if (removeBtn) {
            removeBtn.addEventListener('click', function () {
                const zone = this.closest('.file-upload-zone');
                const input = zone.querySelector('input[type="file"]');
                const placeholder = zone.querySelector('.upload-placeholder');
                const preview = zone.querySelector('.upload-preview');
                if (input) input.value = '';
                if (placeholder) placeholder.classList.remove('d-none');
                if (preview) preview.classList.add('d-none');
            });
        }
    });
}

function initSkillRangeSlider() {
    const slider = document.getElementById('skillProficiency');
    const display = document.getElementById('proficiencyValue');
    if (slider && display) {
        slider.addEventListener('input', function () {
            display.textContent = this.value;
        });
    }
}

function extractYouTubeId(url) {
    const patterns = [
        /(?:youtube\.com\/watch\?v=|youtu\.be\/|youtube\.com\/embed\/|youtube\.com\/v\/|youtube\.com\/shorts\/)([a-zA-Z0-9_-]{11})/,
        /youtube\.com\/watch\?.*v=([a-zA-Z0-9_-]{11})/
    ];
    for (const pattern of patterns) {
        const match = url.match(pattern);
        if (match && match[1]) return match[1];
    }
    return null;
}

function showToast(title, message, type) {
    const toastEl = document.getElementById('liveToast');
    if (!toastEl) return;

    const toastTitle = document.getElementById('toastTitle');
    const toastMessage = document.getElementById('toastMessage');
    const toastIcon = document.getElementById('toastIcon');

    if (toastTitle) toastTitle.textContent = title;
    if (toastMessage) toastMessage.textContent = message;

    if (toastIcon) {
        toastIcon.className = type === 'success'
            ? 'fa-solid fa-circle-check text-success me-2'
            : 'fa-solid fa-circle-exclamation text-danger me-2';
    }

    const toast = new bootstrap.Toast(toastEl);
    toast.show();
}
